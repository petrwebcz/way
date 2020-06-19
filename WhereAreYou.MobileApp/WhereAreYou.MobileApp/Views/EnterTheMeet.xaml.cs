using Newtonsoft.Json;
using System;
using System.Net.Http;
using WhereAreYou.MeetApi.ApiClient;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterTheMeet : ContentPage
    {
        private EnterTheMeetViewModel viewModel;
        private IMeetApiClient meetApiClient;

        public EnterTheMeet(EnterTheMeetViewModel enterTheMeetViewModel) //TODO: Inject wayApiClient., httpclient.... appsettings
        {
            InitializeComponent();

            this.meetApiClient = new MeetApiClient("https://api.petrweb.cz/api", new HttpClient());

            BindingContext = this.viewModel = enterTheMeetViewModel;
        }

        public EnterTheMeet()
        {
            InitializeComponent();

            this.meetApiClient = new MeetApiClient("https://api.petrweb.cz/", new HttpClient());

            BindingContext = viewModel;
        }

        private void CreateNewMeet()
        {
            viewModel = new EnterTheMeetViewModel(new Core.Requests.EnterTheMeet());

            var result = this.meetApiClient.CreateAsync(CreateTestMeet()).Result;

            editorMeetUrl.Text = result.InviteUrl;
        }

        private CreateMeet CreateTestMeet()
        {
            return new CreateMeet()
            {
                Name = "test meet"
            };
        }

        private void buttonEnterTheMeet_Clicked(object sender, EventArgs e)
        {
            this.meetApiClient = new MeetApiClient("https://api.petrweb.cz/", new HttpClient());

        }

        private void buttonCreateMeet_Clicked(object sender, EventArgs e)
        {
            CreateNewMeet();
        }
    }
}