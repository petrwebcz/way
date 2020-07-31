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
            get => nickname; 
            
            set
            {
                SetProperty(ref nickname, value);
            }
        }

        public Position Position
        {
            get => position; 
            
            set
            {
                SetProperty(ref position, value);
            }
        }

        public string Address
        {
            get => address;

            set
            {
                SetProperty(ref address, value);
            }
        }
    }
}