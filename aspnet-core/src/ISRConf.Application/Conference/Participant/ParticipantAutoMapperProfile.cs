using AutoMapper;

namespace ISRConf.Conference.Participant
{
    public class ParticipantAutoMapperProfile : Profile
    {
        public ParticipantAutoMapperProfile() 
        {
            CreateMap<Participant, ParticipantDto>();
            CreateMap<CreateUpdateParticipantDto, Participant>();
        }
    }
}
