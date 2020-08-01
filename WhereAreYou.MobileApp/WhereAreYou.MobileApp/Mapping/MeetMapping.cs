using AutoMapper;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Requests;
using WhereAreYou.MobileApp.Models;

namespace WhereAreYou.MobileApp.Mapping
{
    public class MeetMapping : Profile
    {
        public MeetMapping()
        {
            CreateMapping();
        }

        private void CreateMapping()
        {
            CreateMap<Core.Entity.Location, Xamarin.Forms.Maps.Position>()
              .ForMember(f => f.Latitude, f => f.MapFrom(m => m.Latitude))
              .ForMember(f => f.Longitude, f => f.MapFrom(m => m.Longitude));

            CreateMap<Core.Entity.UserPosition, MeetUser>()
               .ForMember(f => f.Nickname, f => f.MapFrom(m => m.User.Nickname))
               .ForMember(f => f.Position, f => f.MapFrom(m => m.Location))
               .ForMember(f => f.Address, f => f.Ignore());

            CreateMap<Core.Entity.Location, Xamarin.Forms.Maps.MapSpan>()
               .ConstructUsing((l, m) => new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(l.Latitude, l.Longitude), 0.01, 0.01));

            CreateMap<Core.Responses.MeetResponse, Models.Meet>()
              .ForMember(f => f.CenterPoint, f => f.MapFrom(m => m.CenterPoint))
              .ForMember(f => f.MeetName, f => f.MapFrom(m => m.Meet.Name))
              .ForMember(f => f.MeetUsers, f => f.MapFrom(m => m.Users))
              .ForMember(f => f.MeetUrl, f => f.MapFrom(m => m.Meet.InviteUrl));
        }
    }
}
