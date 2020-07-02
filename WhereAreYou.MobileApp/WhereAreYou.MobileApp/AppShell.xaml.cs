using System;
using System.Collections.Generic;
using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public Token Token { get; set; } = new Token("test");

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
