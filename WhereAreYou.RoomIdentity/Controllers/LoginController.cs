using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Utils;
using WhereAreYou.Core.Exceptions;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Requests = WhereAreYou.Core.Requests;
using Responses = WhereAreYou.Core.Responses;
using Exceptions = WhereAreYou.Core.Exceptions;
using WhereAreYou.Core.Infrastructure;

namespace WhereAreYou.RoomIdentity.Controllers
{
    [Route("sso")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ITokenService userService;
        private IHashService hashService;

        public LoginController(ITokenService userService, IHashService service)
        {
            this.userService = userService;
            this.hashService = service;
        }

        [HttpPost]
        [Route("enterTheRoom")]
        [AllowAnonymous]
        [ValidatorFilter]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Responses.Token), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EnterTheRoom([FromBody]  Requests.EnterTheRoom enterTheRoom)
        {
            try
            {
                var user = new User(Guid.NewGuid(), enterTheRoom.Nickname, enterTheRoom.InviteHash);
                var token = userService.GetToken(user, enterTheRoom.InviteHash);

                return Ok(token);
            }

            catch (Exceptions.InvalidTokenException e)
            {
                return Unauthorized(e.Message);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
