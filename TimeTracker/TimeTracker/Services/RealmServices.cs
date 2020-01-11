using Realms;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeTracker.Interfaces;
using Xamarin.Forms;

namespace TimeTracker.Services
{
    public sealed class RealmServices : IRealmServices
    {
        #region Properties & Fields

        private static RealmServices _realmServices;

        private static Realm _realm;

        public RealmServices GetRealmServices => _realmServices ?? (_realmServices = new RealmServices());

        private Realm GetRealmInstance => _realm ?? (_realm = Realm.GetInstance(RealmConfiguration.DefaultConfiguration.DatabasePath));

        #endregion Properties & Fields

        public async Task<IQueryable<T>> GetItemsAsync<T>() where T : RealmObject
        {
            try
            {
                var realm = GetRealmInstance;
                var list = realm.All<T>();
                return await Task.FromResult(list);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($" Realms AddItemAsync Exception :  {ex.Message}");
                return await Task.FromResult(Activator.CreateInstance<IQueryable<T>>());
            }
        }

        public async Task<bool> AddItemAsync<T>(T item) where T : RealmObject
        {
            try
            {
                if (item == null)
                {
                    return await Task.FromResult(false);
                }

                var realm = GetRealmInstance;

                realm.Write(() =>
                {
                    realm.Add(item, update: true);
                });

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($" Realms AddItemAsync Exception :  {ex.Message}");
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteItemAsync<T>(T item) where T : RealmObject
        {
            try
            {
                if (item == null)
                    return await Task.FromResult(true);

                var realm = GetRealmInstance;

                using (var trans = realm.BeginWrite())
                {
                    realm.Remove(item);
                    trans.Commit();
                }
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($" Realms DeleteItemAsync Exception :  {ex.Message}");
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteAllItems<T>() where T : RealmObject
        {
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var realm = GetRealmInstance;
                    using (var trans = realm.BeginWrite())
                    {
                        // Clear All Data
                        realm.RemoveAll<T>();
                        trans.Commit();
                    }
                });
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($" Realms DeleteAllItems Exception :  {ex.Message}");
                return await Task.FromResult(false);
            }
        }
    }
}