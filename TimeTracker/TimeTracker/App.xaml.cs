using Realms;
using Xamarin.Forms;

namespace TimeTracker
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<Interfaces.IRealmServices, Services.RealmServices>();
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            RealmConfiguration config = new RealmConfiguration
            {
                ShouldDeleteIfMigrationNeeded = true
            };
            RealmConfiguration.DefaultConfiguration = config;

            string dbPath = RealmConfiguration.DefaultConfiguration.DatabasePath;
            System.Diagnostics.Debug.WriteLine($"Database path : {dbPath}");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}