using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhereAreYou.MobileApp.Services;
using WhereAreYou.MobileApp.Views;
using Autofac;
using WhereAreYou.MeetApi.ApiClient;

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
