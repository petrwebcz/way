using WhereAreYou.Core.Responses;

namespace WhereAreYou.MobileApp.Models
{
    public class SavedToken
    {
        public const string TOKEN_SAVED_MESSAGE = "TOKEN_SAVED";
        public const string TOKEN_REMOVED_MESSAGE = "TOKEN_REMOVED";

        public string MeetHash { get; set; }
        public string MeetName { get; set; }
        public Token Token { get; set; }
    }
}