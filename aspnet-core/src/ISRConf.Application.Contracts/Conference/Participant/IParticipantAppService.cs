using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ISRConf.Conference.Participant
{
    public interface IParticipantAppService :
        ICrudAppService<
            ParticipantDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateParticipantDto>
    {

    }
}
