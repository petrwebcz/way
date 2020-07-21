using System.Collections.Generic;
using Xamarin.Forms;
using WhereAreYou.MobileApp.Models;
using WhereAreYou.MobileApp.Services;
using WhereAreYou.MeetApi.ApiClient;
using System.Collections.ObjectModel;
using WhereAreYou.Core.Responses;
using Autofac;
using WhereAreYou.Sso.ApiClient;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class BaseViewModel : BaseModel
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IMeetApiClient MeetApiClient { get; set; }
        public ISsoApiClient SsoApiClient { get; set; }
        public ObservableCollection<KeyValuePair<string, Token>> Tokens { get; set; } = new ObservableCollection<KeyValuePair<string, Token>>();
        

        public BaseViewModel()
        {
            MeetApiClient = App.Container.Resolve<IMeetApiClient>();
            SsoApiClient = App.Container.Resolve<ISsoApiClient>();
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
    }
}
