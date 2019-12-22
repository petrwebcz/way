using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereAreYou.Web.Configuration;

namespace WbereAreYou.Web.Controller
{
    [Route("api/configuration")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private ISpaSettings settings;
        public ConfigurationController(ISpaSettings settings)
        {
            this.settings = settings;
        }

        [HttpGet]
        [Route("get")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(SpaSettings), StatusCodes.Status200OK)]
        public IActionResult GetConfiguration()
        {
            return Ok(settings);
        }
    }
}