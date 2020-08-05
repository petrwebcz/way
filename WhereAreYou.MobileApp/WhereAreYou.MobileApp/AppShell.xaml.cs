using System;
using System.Linq;
using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.Models;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private BaseViewModel viewModel = new BaseViewModel();

        public AppShell()
        {
            InitializeComponent();

            BindingContext = viewModel = new BaseViewModel();
            MessagingCenter.Subscribe<SavedToken>(this, SavedToken.TOKEN_SAVED_MESSAGE, AddMeetShellContent);
            MessagingCenter.Subscribe<SavedToken>(this, SavedToken.TOKEN_REMOVED_MESSAGE, RemoveMeetShellContent);
        }

        //TODO: Try modify to MVVM pattern (xamarin shell flyout item navigation binding not work).
        public void AddMeetShellContent(SavedToken token)
        {
            var userData = token.ToUserData();
           
            var tab = new Tab();
            tab.Route = userData.MeetInviteHash;
            tab.Title = token.MeetName;

            tab.Items.Add(new ShellContent()
            {
                Route = "map",
                Content = new Views.MeetPage()
                {
                    Title = token.MeetName,
                    Token = token
                },
                Title = "Mapa"
            }); ;

            tab.Items.Add(new ShellContent()
            {
                Route = "people",
                Content = new Views.PeoplePage()
                {
                    Title = token.MeetName,
                    Token = token
                },
                Title = "Lidé"
            });

            tab.Items.Add(new ShellContent()
            {
                Route = "settings",
                Content = new Views.SettingsPage()
                {
                    Title = token.MeetName,
                    Token = token
                },  
                Title = "Nastavení"
            });

            flyItem.Items.Add(tab);

            Shell.Current.GoToAsync($"//{userData.MeetInviteHash}/map");
        }

        private void RemoveMeetShellContent(SavedToken token)
        {
            var userData = token.ToUserData();  
            var shellContent = flyItem.Items.FirstOrDefault(w => w.Route == userData.MeetInviteHash);

            if (shellContent == null)
            {
                throw new ApplicationException($"Meet {userData.MeetInviteHash} was not found.");
            }

            Device.InvokeOnMainThreadAsync(() =>
            {
                Shell.Current.GoToAsync($"//enterTheMeet");
                flyItem.Items.Remove(shellContent);
            });
        }
    }
}
