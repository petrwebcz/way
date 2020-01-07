using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WhereAreYou.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using WhereAreYou.Core.Entity;
using WhereAreYou.MeetApi.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Requests = WhereAreYou.Core.Requests;
using Responses = WhereAreYou.Core.Responses;
using WhereAreYou.Core.Infrastructure;
using Newtonsoft.Json;

namespace WhereAreYou.MeetApi.Controllers
{
    [ApiController]
    [Route("api/v1/meet/position/")]
    public class PositionController : WayController
    {
        private IMeetRepository meetRepository;

        public PositionController(IMeetRepository meetRepository)
        {
            this.meetRepository = meetRepository;
        }

        [HttpPost]
        [Route("add")]


          
        [Authorize]
        [ValidatorFilter]
        [UserDataActionFilter]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]     
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Responses.ValidationErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Responses.ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddPosition([FromBody]Requests.AddOrUpdatePosition updatePosition)
        {
            await meetRepository.AddLocationAsync(UserData.User, updatePosition.Location);
            return Ok();
        }
            
        [HttpPut]
        [Route("update")]
        [Authorize]
        [ValidatorFilter]
        [UserDataActionFilter]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Responses.ValidationErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Responses.ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePosition([FromBody]Requests.AddOrUpdatePosition updatePosition)
        {
            await meetRepository.UpdateLocationAsync(UserData.User, updatePosition.Location);
            return Ok();
        }
    }
}
