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
        private void AddMeetShellContent(SavedToken savedToken)
        {
            var tab = new Tab();
            tab.Route = savedToken.MeetHash;
            tab.Title = savedToken.MeetName;

            tab.Items.Add(new ShellContent()
            {
                Route = "map",
                Content = new Views.MeetPage()
                {
                    Title = savedToken.MeetName,
                    Token = new Token(savedToken.Token)
                },
                Title = "Mapa"
            }); ;

            tab.Items.Add(new ShellContent()
            {
                Route = "people",
                Content = new Views.PeoplePage()
                {
                    Title = savedToken.MeetName,
                    Token = new Token(savedToken.Token)
                },
                Title = "Lidé"
            });

            tab.Items.Add(new ShellContent()
            {
                Route = "settings",
                Content = new Views.SettingsPage()
                {
                    Title = savedToken.MeetName,
                    Token = new Token(savedToken.Token)
                },
                Title = "Nastavení"
            });

            flyItem.Items.Add(tab);

            Shell.Current.GoToAsync($"//{savedToken.MeetHash}/map").Wait(); 
        }

        private void RemoveMeetShellContent(SavedToken savedToken)
        {
            var shellContent = flyItem.Items.FirstOrDefault(w => w.Route == savedToken.MeetHash);

            if(shellContent == null)
            {
                throw new ApplicationException($"Meet {savedToken.MeetHash} was not found.");
            }

            Shell.Current.GoToAsync($"//enterTheMeet").Wait();
            flyItem.Items.Remove(shellContent);
        }
    }
}
