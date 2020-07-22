using WhereAreYou.Core.Responses;

namespace WhereAreYou.MobileApp.Models
{
    public class SavedToken
    {
        public string MeetHash { get; set; }
        public string MeetName { get; set; }
        public Token Token { get; set; }
    }
}