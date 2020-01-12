using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            set { SetProperty(ref _item, value, onChanged: async () => await TimeSpentChange()); }
        }

        private string _timeSpent;

        public string TimeSpent
        {
            get { return _timeSpent; }
            set { SetProperty(ref _timeSpent, value); }
        }

        private DateTime _dateTimeProperty = DateTime.Now;

        public DateTime DateTimeProperty
        {
            get { return _dateTimeProperty; }
            set { SetProperty(ref _dateTimeProperty, value, onChanged: async () => await DateChangeHandler(value)); }
        }

        private ICollection<Item> _itemsList;

        public ICollection<Item> ItemsList
        {
            get { return _itemsList; }
            set { SetProperty(ref _itemsList, value); }
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        #endregion Properties & Fields

        public HomePageViewModel()
        {
            Title = AppResources.HomeTitle;

            SaveCommand = new Command(async () => await SaveItem());
            DeleteCommand = new Command(async () => await ClearDB());
            _ = GetDataFromDBAsync();
        }

        #region Tasks & Methods

        private async Task TimeSpentChange()
        {
            if (Item != null)
            {
                var result = Item.OutTime - Item.InTime;

                TimeSpent = $"Spent time : {result.ToString()}";
            }
            await Task.FromResult(true);
        }

        private async Task DateChangeHandler(DateTime dates)
        {
            if (dates != null)
            {
                Item = new Item
                { Id = dates.ToShortDateString(), Description = dates.ToLongDateString() };
                await GetDataFromDBAsync();
            }

            await Task.FromResult(true);
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
                if (list != null && list.Count() > 0)
                {
                    ItemsList = new ObservableCollection<Item>(list.ToList());
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

        private async Task ClearDB()
        {
            try
            {
                bool warning = await App.Current.MainPage.DisplayAlert(AppResources.AlertHeader, AppResources.AlertClearDB, AppResources.Ok, AppResources.Cancel);
                if (warning)
                {
                    bool result = await RealmServices.DeleteAllItems<Item>();
                    if (result)
                    {
                        DateTimeProperty = DateTime.Now;
                        ItemsList = default;
                        Item = new Item();
                        await App.Current.MainPage.DisplayAlert(AppResources.AlertHeader, AppResources.ClearDB, AppResources.Ok);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert(AppResources.AlertHeader, AppResources.GenericError, AppResources.Ok);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Clear DB error : {ex.Message}");
            }
        }

        #endregion Tasks & Methods
    }
}