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
        }
    }
}
