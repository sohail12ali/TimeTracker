using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeTracker.Models;
using Xamarin.Forms;

namespace TimeTracker.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Properties & Fields

        private Item _item = new Item();

        public Item Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public ICommand SaveCommand { get; }

        #endregion Properties & Fields

        public HomePageViewModel()
        {
            Title = AppResources.HomeTitle;

            SaveCommand = new Command(async () => await SaveItem());
            _ = GetDataFromDBAsync();
        }

        private async Task GetDataFromDBAsync()
        {
            try
            {
                var list = await RealmServices.GetItemsAsync<Item>();
                var result = list?.Where(x => x.Id == Item.Id)?.FirstOrDefault();
                if (result != null)
                {
                    Item = result;
                }
                else
                {
                    await SaveItem();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DB error : {ex.Message}");
            }
        }

        private async Task SaveItem()
        {
            var IsSaved = await RealmServices.AddItemAsync<Item>(Item);
            if (IsSaved)
            {
                await App.Current.MainPage.DisplayAlert(AppResources.AlertHeader, AppResources.SaveSuccess, AppResources.Ok);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(AppResources.AlertHeader, AppResources.SaveFail, AppResources.Ok);
            }
        }
    }
}