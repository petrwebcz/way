using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Meet : ContentPage
    {
        private MeetViewModel viewModel;

        public Meet()
        {
            InitializeComponent();
            BindingContext = viewModel = new MeetViewModel(Token);
        }

        public Token Token
        {
            set { SetValue(TokenProperty, value); }
            get { return (Token)GetValue(TokenProperty); }
        }
        public static readonly BindableProperty TokenProperty = BindableProperty.Create(nameof(Token), typeof(Token), typeof(Token));
    }
}