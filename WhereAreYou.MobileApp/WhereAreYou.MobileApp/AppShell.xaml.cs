using System;
using System.Collections.Generic;
using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private BaseViewModel viewModel;

        public Token Token { get; set; }

        public AppShell()
        {
            InitializeComponent();
            BindingContext = viewModel = new EnterTheMeetViewModel();
        }
    }
}
