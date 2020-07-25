using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.Models;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public Token Token { get; set; } = new Token("test");
        private BaseViewModel viewModel = new BaseViewModel();

        public AppShell()
        {
            InitializeComponent();
            BindingContext = viewModel = new BaseViewModel();
            Routing.RegisterRoute("way/meet", typeof(MeetViewModel));
            MessagingCenter.Subscribe<SavedToken>(this, SavedToken.TOKEN_SAVED_MESSAGE, AddMeetShellContent);
        }

        private void AddMeetShellContent(SavedToken token)
        {
            tabSavedMeets.Items.Add(new ShellContent()
            {
                Content = new Views.MeetPage()
                {
                    Token = new Token(token.Token), //TODO: Use string in Meet! 
                    Title = token.MeetName
                },
                Title = token.MeetName
            });
        }
    }
}
