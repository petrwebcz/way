using System;
using System.Collections.ObjectModel;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms.Maps;

namespace WhereAreYou.MobileApp.Models
{
    public class Meet : BaseModel
    {
        private MapSpan centerPoint;
        private string meetName;

        public Meet()
        {
            MeetUsers = new ObservableCollection<MeetUser>();
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