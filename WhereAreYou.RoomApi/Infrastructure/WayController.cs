using Microsoft.AspNetCore.Mvc;
using WhereAreYou.Core.Model;

namespace WhereAreYou.RoomApi.Controllers
{
    public abstract class WayController : Controller
    {
        public UserData UserData { get; set; }
    }
}