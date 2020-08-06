using WhereAreYou.MeetApi.ApiClient;
using Autofac;
using WhereAreYou.Sso.ApiClient;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class BaseViewModel : BaseModel
    {
        private bool isBusy = false;
        private string title = string.Empty;

        public IMeetApiClient MeetApiClient { get; set; }
        public ISsoApiClient SsoApiClient { get; set; }

        public BaseViewModel()
        {
            MeetApiClient = App.Container.Resolve<IMeetApiClient>();
            SsoApiClient = App.Container.Resolve<ISsoApiClient>();
        }

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            set
            {
                SetProperty(ref isBusy, value);
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                SetProperty(ref title, value);
            }
        }

        public Command HelpCommand
        {
            get
            {
                return new Command<string>(async (url) => await Launcher.OpenAsync(url));
            }
        }
    }
}
