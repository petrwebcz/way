using SQLite;
using System;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.MobileApp.Models
{
    [Table("savedToken")]
    public class SavedToken : Token
    {
        public const string TOKEN_SAVED_MESSAGE = "TOKEN_SAVED";
        public const string TOKEN_REMOVED_MESSAGE = "TOKEN_REMOVED";

        public SavedToken()
        {
        }
         
        public SavedToken(string meetName, string jwt) : base(jwt)
        {
            MeetName = meetName ?? throw new ArgumentNullException(nameof(meetName));
        }

        public string MeetName { get; set; }

        [PrimaryKey]
        public override string Jwt
        {
            get
            {
                return base.Jwt;
            }

            set
            {
                base.Jwt = value;
            }
        }
    }
}