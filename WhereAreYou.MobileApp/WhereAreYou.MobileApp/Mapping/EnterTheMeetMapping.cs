using AutoMapper;
using WhereAreYou.Core.Entity;
using WhereAreYou.Core.Requests;
using WhereAreYou.MobileApp.Models;
using WhereAreYou.MobileApp.ViewModels;

namespace WhereAreYou.MobileApp.Mapping
{
    public class EnterTheMeetMapping : Profile
    {
        public EnterTheMeetMapping()
        {
            CreateMapping();
        }

        private void CreateMapping()
        {
            CreateMap<EnterTheMeetViewModel, EnterTheMeet>()
                .ForMember(f => f.InviteUrl, f => f.MapFrom(m => m.InviteUrl))
                .ForMember(f => f.Nickname, f => f.MapFrom(m => m.Nickname))
                .ForMember(f => f.InviteHash, f => f.MapFrom(m => m.InviteHash));

            CreateMap<EnterTheMeetViewModel, CreateMeet>()
                .ForMember(f => f.Name, f => f.MapFrom(m => m.MeetName));

            CreateMap<Location, Xamarin.Forms.Maps.Position>()
                .ForMember(f => f.Latitude, f => f.MapFrom(m => m.Latitude))
                .ForMember(f => f.Longitude, f => f.MapFrom(m => m.Longitude));

            CreateMap<Position, MeetUser>()
                .ForMember(f => f.Nickname, f => f.MapFrom(m => m.User.Nickname))
                .ForMember(f => f.Position, f => f.MapFrom(m => m.Location));
        }
    }
}
