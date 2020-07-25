using System.Linq;
using WhereAreYou.MobileApp.ViewModels;

namespace WhereAreYou.MobileApp.Models
{
    public class EnterTheMeet : BaseModel
    {
        private string nickname;
        private string inviteUrl;
        private string meetName;

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

        public string InviteHash => InviteUrl.Split('/').Last();
 
        public string InviteUrl
        {
            get
            {
                return inviteUrl;
            }

            set
            {
                SetProperty(ref inviteUrl, value);
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
    }
}