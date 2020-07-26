using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.Controls;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Position = Xamarin.Forms.Maps.Position;

namespace WhereAreYou.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetPage : ContentPage
    {
        private MeetViewModel viewModel;

        public MeetPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MeetViewModel();
        }

        public Token Token
        {
            set
            {
                SetValue(TokenProperty, value);
                viewModel.Token = value;
            }

            get
            {
                return (Token)GetValue(TokenProperty);
            }
        }

        public static readonly BindableProperty TokenProperty = BindableProperty.Create(nameof(Token), typeof(Token), typeof(Token));
    }
}