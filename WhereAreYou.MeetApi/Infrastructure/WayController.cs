using Microsoft.AspNetCore.Mvc;
using WhereAreYou.Core.Model;

namespace WhereAreYou.MeetApi.Controllers
{
    public abstract class WayController : Controller
    {
        public UserData UserData { get; set; }
    }
}