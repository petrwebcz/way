using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using WhereAreYou.Core.Model;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.MobileApp.ViewModels
{
    public static class TokenExtensions
    {
        public static UserData ToUserData(this Token token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = (JwtSecurityToken)handler.ReadToken(token.Jwt);
            var json = jsonToken.Claims.First(claim => claim.Type == ClaimTypes.UserData).Value;

            var userData = JsonConvert.DeserializeObject<UserData>(json);
            return userData;
        }
    }
}