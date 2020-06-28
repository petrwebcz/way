using System.ComponentModel;
using WhereAreYou.MobileApp.ViewModels;
using Xamarin.Forms.Maps;

namespace WhereAreYou.MobileApp.Models
{
    public class MeetUser : BaseViewModel
    {
        private string nickname;
        private Position position;

        public string Nickname
        {
            get => nickname; 
            
            set
            {
                SetProperty(ref nickname, value);
            }
        }

        public Xamarin.Forms.Maps.Position Position
        {
            get => position; 
            
            set
            {
                SetProperty(ref position, value);
            }
        }
    }
}