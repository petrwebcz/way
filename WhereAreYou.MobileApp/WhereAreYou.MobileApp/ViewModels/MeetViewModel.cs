using System.Collections.ObjectModel;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Responses;
using WhereAreYou.MobileApp.Models;
using Xamarin.Forms.Maps;

namespace WhereAreYou.MobileApp.ViewModels
{
    public class MeetViewModel : BaseViewModel
    {
        private MapSpan centerPoint;
        private string meetName;
        private Token token;

        public MeetViewModel(Token token)
        {
            CenterPoint = new MapSpan(new Xamarin.Forms.Maps.Position(50.19385934655583, 14.66693449958008), 0.01, 0.01);
            MeetUsers = new ObservableCollection<MeetUser>()
            {
                new MeetUser()
                {
                    Nickname = "Petr",
                    Position = new Xamarin.Forms.Maps.Position(50.19385934655583, 14.66693449958008)
                }
            };
        }

        public MapSpan CenterPoint
        {
            get => centerPoint;
            
            set
            {
                SetProperty(ref centerPoint, value);
            }
        }

        public string MeetName
        {
            get => meetName;

            set
            {
                SetProperty(ref meetName, value);
            }
        }

        public ObservableCollection<MeetUser> MeetUsers { get; set; }
    }
}