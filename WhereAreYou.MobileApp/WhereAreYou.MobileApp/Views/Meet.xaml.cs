using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhereAreYou.Core.Entity;
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
            BindingContext = viewModel = new MeetViewModel();
        }
    }
}