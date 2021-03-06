﻿using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeoplePage : ContentPage
    {
        private PeopleViewModel viewModel;

        public PeoplePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PeopleViewModel();
        }

        public Token Token
        {
            set
            {
                SetValue(TokenProperty, value);
                viewModel.Token = value;

                if (value != null)
                {
                    viewModel.Run();
                }
            }

            get
            {
                return (Token)GetValue(TokenProperty);
            }
        }

        public static readonly BindableProperty TokenProperty = BindableProperty.Create(nameof(Token), typeof(Token), typeof(Token));
    }
}