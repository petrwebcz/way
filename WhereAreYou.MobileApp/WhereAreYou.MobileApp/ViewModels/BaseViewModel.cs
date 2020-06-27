using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using WhereAreYou.MobileApp.Models;
using WhereAreYou.MobileApp.Services;
using WhereAreYou.MeetApi.ApiClient;
using System.Net.Http;
using System.Collections.ObjectModel;
using WhereAreYou.Core.Responses;
using Autofac;
using WhereAreYou.Sso.ApiClient;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IMeetApiClient MeetApiClient { get; set; }
        public ISsoApiClient SsoApiClient { get; set; }
        public ObservableCollection<Token> Tokens { get; set; } = new ObservableCollection<Token>();

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

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
