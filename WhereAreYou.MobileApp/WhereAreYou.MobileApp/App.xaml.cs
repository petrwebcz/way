using Xamarin.Forms;
using WhereAreYou.MobileApp.Services;
using Autofac;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.Sso.ApiClient;

namespace WhereAreYou.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            var builder = new ContainerBuilder();
            builder.RegisterType<IMeetApiClient>();
            builder.RegisterType<ISsoApiClient>();
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
