using AutoMapper;
using System;
using WhereAreYou.Core.Requests;
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
        }
    }
}
