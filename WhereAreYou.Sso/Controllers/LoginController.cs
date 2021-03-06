﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using WhereAreYou.Core.Infrastructure;
using WhereAreYou.Core.Services;
using WhereAreYou.Core.Intefaces;
using WhereAreYou.Core.Exceptions;
using Requests = WhereAreYou.Core.Requests;
using Responses = WhereAreYou.Core.Responses;
using Exceptions = WhereAreYou.Core.Exceptions;
using Entity = WhereAreYou.Core.Entity;
using WhereAreYou.Sso;

namespace WhereAreYou.Sso.Controllers
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
            hashService = service;
        }

        [HttpPost]
        [Route("enterTheMeet")]
        [ValidatorFilter]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Responses.Token), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses.ValidationErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Responses.ErrorResponse), StatusCodes.Status404NotFound)]
        public IActionResult EnterTheMeet([FromBody] Requests.EnterTheMeet enterTheMeet)
        {
            var user = Core.Entity.User.Create(enterTheMeet.Nickname, enterTheMeet.InviteHash);
            var token = userService.GetToken(user, enterTheMeet.InviteHash);

            return Ok(token);
        }
    }
}
