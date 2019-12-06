using Microsoft.IdentityModel.Tokens;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.RoomIdentity
{
    public interface ITokenService
    {
        Token GetToken(User user, string inviteRoomHash);
    }
}