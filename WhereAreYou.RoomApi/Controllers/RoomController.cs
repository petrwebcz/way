using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WhereAreYou.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using WhereAreYou.Core.Entity;
using WhereAreYou.RoomApi.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Requests = WhereAreYou.Core.Requests;
using Responses = WhereAreYou.Core.Responses;
using WhereAreYou.Core.Infrastructure;

namespace WhereAreYou.RoomApi.Controllers
{
    [ApiController]
    [Route("api/room/")]
    public class RoomController : WayController
    {
        private IRoomRepository roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        [ValidatorFilter]
        [UserDataActionFilter]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Responses.CreatedRoom), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Requests.CreateRoom createRoom)
        {
            var result = await roomRepository.CreateRoom(createRoom.Name);
            return Created(result.InviteUrl, result);
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        [ValidatorFilter]
        [UserDataActionFilter]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var result = await roomRepository.GetRoomAsync(UserData.RoomInviteHash);

            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPut]
        [Route("position/update")]
        [Authorize]
        [ValidatorFilter]
        [UserDataActionFilter]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePosition([FromBody]Requests.UpdatePosition updatePosition)
        {
            await roomRepository.PutLocationAsync(UserData.User, updatePosition.Location);
            return Ok();
        }
    }
}
