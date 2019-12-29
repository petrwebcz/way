using System.Collections.Generic;
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

namespace WhereAreYou.MeetApi.Controllers
{
    [ApiController]
    [Route("api/v1/meet/")]
    public class MeetController : WayController
    {
        private IMeetRepository meetRepository;

        public MeetController(IMeetRepository meetRepository)
        {
            this.meetRepository = meetRepository;
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        [ValidatorFilter]
        [UserDataActionFilter]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Responses.CreatedMeet), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Responses.ValidationErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Responses.ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] Requests.CreateMeet createMeet)
        {
            var result = await meetRepository.CreateMeetAsync(createMeet.Name);
            return Created(result.InviteUrl, result);
        }                   

        [HttpGet]
        [Route("get")] 
        [Authorize]
        [ValidatorFilter]
        [UserDataActionFilter]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Meet), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Responses.ValidationErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Responses.ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await meetRepository.GetMeetAsync(UserData.MeetInviteHash);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAll")]
        [AllowAnonymous]
        [ValidatorFilter]       
        [UserDataActionFilter]      
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<Meet>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Responses.ValidationErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Responses.ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var result = await meetRepository.GetMeetsAsync();
            return Ok(result);
        }
    }
}
