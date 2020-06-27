using System;
using System.Collections.Generic;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private BaseViewModel viewModel;
        public AppShell()
        {
            InitializeComponent();
            BindingContext = viewModel = new EnterTheMeetViewModel()
            {
                Tokens = new System.Collections.ObjectModel.ObservableCollection<Core.Responses.Token>()
                 {
                      new Core.Responses.Token("test"),
                      new Core.Responses.Token("test2")
                 }
            };
             
        }
    }
}
