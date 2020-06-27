using Xamarin.Forms;
using WhereAreYou.MobileApp.Services;
using Autofac;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.Sso.ApiClient;
using System.Net.Http;

namespace WhereAreYou.MobileApp
{

    public partial class App : Application
    {
        public static IContainer Container { get; private set; } //No DI (service locator for now).

        public App()
        {
            InitializeIoC();
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        private void InitializeIoC()
        {
            if (Container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterInstance<IMeetApiClient>(new MeetApiClient("https://api.petrweb.cz/", new HttpClient())); 
                builder.RegisterInstance<ISsoApiClient>(new SsoApiClient("https://sso.petrweb.cz/", new HttpClient())); 
                Container = builder.Build();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
