using System.Collections.ObjectModel;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms.Maps;

namespace WhereAreYou.MobileApp.Models
{
    public class Meet : BaseModel
    {
        private MapSpan centerPoint;
        private string meetName;
        private string meetUrl;
        private string meetHash;

        public Meet()
        {
            MeetUsers = new ObservableCollection<MeetUser>();
            
        }

        public MapSpan CenterPoint
        {
            get
            {
                return centerPoint;
            }

            set
            {
                SetProperty(ref centerPoint, value);
            }
        }

        public string MeetName
        {
            get
            {
                return meetName;
            }

            set
            {
                SetProperty(ref meetName, value);
            }
        }

        public string MeetUrl
        {
            get
            {
                return meetUrl;
            }

            set
            {
                SetProperty(ref meetUrl, value);
            }
        }

        public string MeetHash
        {
            get
            {
                return meetHash;
            }

            set
            {
                SetProperty(ref meetHash, value);
            }
        }

        public ObservableCollection<MeetUser> MeetUsers { get; set; }
    }
}