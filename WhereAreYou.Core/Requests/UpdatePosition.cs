using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WhereAreYou.Core.Entity;

namespace WhereAreYou.Core.Requests
{
    public class UpdatePosition
    {
        [Required]
        public Location Location { get; set; }
    }
}