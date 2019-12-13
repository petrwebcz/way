using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WhereAreYou.Core.Configuration;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Model;
using WhereAreYou.Core.Responses;
using WhereAreYou.Core.Services;

namespace WhereAreYou.RoomIdentity.Services
{
    public class TokenService : ITokenService
    {
        private readonly IAppSettings settings;
        private readonly IHashService hashService;
        public TokenService(IAppSettings keySettings, IHashService service)
        {
            settings = keySettings;
            hashService = service;
        }

        public Token GetToken(User user, string inviteRoomHash)
        {
            var userData = new UserData(user, inviteRoomHash);
            var token = MakeToken(userData);
            return new Token(token);
        }

        private string MakeToken(UserData userData)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.JwtSecret);

            var claims = new Claim[] {
                         new Claim(ClaimTypes.Name, userData.User.Nickname),
                         new Claim(ClaimTypes.UserData, userData.ToJson())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                         SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}