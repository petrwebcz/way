using AutoMapper;
using WhereAreYou.MobileApp.Models;

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
            CreateMap<EnterTheMeet, Core.Requests.EnterTheMeet>()
                .ForMember(f => f.InviteUrl, f => f.MapFrom(m => m.InviteUrl))
                .ForMember(f => f.Nickname, f => f.MapFrom(m => m.Nickname))
                .ForMember(f => f.InviteHash, f => f.MapFrom(m => m.InviteHash));

            CreateMap<EnterTheMeet, Core.Requests.CreateMeet>()
                .ForMember(f => f.Name, f => f.MapFrom(m => m.MeetName));

            CreateMap<Core.Responses.CreatedMeet, EnterTheMeet>()
                .ForMember(f => f.MeetName, f => f.MapFrom(m => m.Name))
                .ForMember(f => f.Nickname, f => f.Ignore()) //TODO: Set string empty
                .ForMember(f => f.InviteUrl, f => f.MapFrom(m => m.InviteUrl))
                .ForMember(f => f.InviteHash, f => f.MapFrom(m => m.InviteHash));
        }
    }
}
