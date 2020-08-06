using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms.Maps;

namespace WhereAreYou.MobileApp.Models
{
    public class MeetUser : BaseViewModel
    {
        private string nickname;
        private Position position;
        private string address;

        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                SetProperty(ref nickname, value);
            }
        }

        public Position Position
        {
            get
            {
                return position;
            }

            set
            {
                SetProperty(ref position, value);
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                SetProperty(ref address, value);
            }
        }
    }
}