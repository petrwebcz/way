using System.Collections.Generic;
using WhereAreYou.MeetApi.ApiClient;
using System.Collections.ObjectModel;
using WhereAreYou.Core.Responses;
using Autofac;
using WhereAreYou.Sso.ApiClient;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class BaseViewModel : BaseModel
    {
        public IMeetApiClient MeetApiClient { get; set; }
        public ISsoApiClient SsoApiClient { get; set; }
        public ObservableCollection<KeyValuePair<string, Token>> Tokens { get; set; } = new ObservableCollection<KeyValuePair<string, Token>>();
        //TODO: Remove Tokens

        public BaseViewModel()
        {
            MeetApiClient = App.Container.Resolve<IMeetApiClient>();
            SsoApiClient = App.Container.Resolve<ISsoApiClient>();
            Tokens.Add(new KeyValuePair<string, Token>("Test1", new Token("Test1")));
            Tokens.Add(new KeyValuePair<string, Token>("Test2", new Token("Test2")));
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
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
