using System;
using System.Collections.Generic;
using System.Text;
using WhereAreYou.Core.Model;
using System.Security.Claims;
using Newtonsoft.Json;

namespace WhereAreYou.Core.Extensions
{
    public static class ClaimsExtensions
    {
        public static UserData ToUserData(this Claim claim)
        {
            if (claim.Type != ClaimTypes.UserData)
                throw new Exception("claim is must be user data type");

            var result = JsonConvert.DeserializeObject<UserData>(claim.Value);
            return result;
        }
    }
}
