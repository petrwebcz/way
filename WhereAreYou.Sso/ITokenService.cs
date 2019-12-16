using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Responses;

namespace WhereAreYou.Sso
{
    public interface ITokenService
    {
        Token GetToken(User user, string inviteRoomHash);
    }
}