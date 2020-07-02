using AutoMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Responses;
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
            CreateMap<Location, Xamarin.Forms.Maps.Position>()
              .ForMember(f => f.Latitude, f => f.MapFrom(m => m.Latitude))
              .ForMember(f => f.Longitude, f => f.MapFrom(m => m.Longitude));

            CreateMap<UserPosition, MeetUser>()
               .ForMember(f => f.Nickname, f => f.MapFrom(m => m.User.Nickname))
               .ForMember(f => f.Position, f => f.MapFrom(m => m.Location));

            CreateMap<Location, Xamarin.Forms.Maps.MapSpan>()
               .ConstructUsing((l, m) => new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(l.Latitude, l.Longitude), 0.01, 0.01));

            CreateMap<MeetResponse, Models.Meet>()
              .ForMember(f => f.CenterPoint, f => f.MapFrom(m => m.CenterPoint))
              .ForMember(f => f.MeetName, f => f.MapFrom(m => m.Meet))
              .ForMember(f => f.MeetUsers, f => f.MapFrom(m => m.Users));
        }
    }
}
