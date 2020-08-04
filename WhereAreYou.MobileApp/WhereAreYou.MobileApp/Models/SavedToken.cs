using SQLite;
using System;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.MobileApp.Models
{
    [Table("savedToken")]
    public class SavedToken
    {
        public const string TOKEN_SAVED_MESSAGE = "TOKEN_SAVED";
        public const string TOKEN_REMOVED_MESSAGE = "TOKEN_REMOVED";

        public SavedToken()
        {
        }

        public SavedToken(string meetHash, string meetName, string token)
        {
            MeetHash = meetHash ?? throw new ArgumentNullException(nameof(meetHash));
            MeetName = meetName ?? throw new ArgumentNullException(nameof(meetName));
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        [Unique]
        [PrimaryKey]
        public string MeetHash { get; set; }
        public string MeetName { get; set; }
        public string Token { get; set; }
    }
}