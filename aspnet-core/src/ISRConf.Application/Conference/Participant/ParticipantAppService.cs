using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ISRConf.Conference.Participant
{
    public class ParticipantAppService :
        CrudAppService<
            Participant,
            ParticipantDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateParticipantDto>,
        IParticipantAppService
    {
        protected ParticipantManager ParticipantManager;

        public ParticipantAppService(IRepository<Participant, Guid> repository, ParticipantManager participantManager)
            : base(repository)
        {
            this.ParticipantManager = participantManager;
        }

        public async override Task<ParticipantDto> CreateAsync(CreateUpdateParticipantDto newParticipantDto)
        {
            var newParticipant = await ParticipantManager.CrateParticipantAsync(
                newParticipantDto.FirstName,
                newParticipantDto.Surname,
                newParticipantDto.EmailAdress,
                newParticipantDto.PhoneNumber,
                newParticipantDto.TicketType);

            await Repository.InsertAsync(newParticipant);
            return ObjectMapper.Map<Participant, ParticipantDto>(newParticipant);
        }

        public async override Task<ParticipantDto> UpdateAsync(Guid id, CreateUpdateParticipantDto newParticipantDto)
        {
            var dbParticipant = await Repository.GetAsync(id);

            dbParticipant.SetFirstName(newParticipantDto.FirstName);
            dbParticipant.SetSurname(newParticipantDto.Surname);

            if (newParticipantDto.EmailAdress != dbParticipant.EmailAdress)
                await ParticipantManager.ChangeParticipantEmailAdressAsync(dbParticipant, newParticipantDto.EmailAdress);

            dbParticipant.SetPhoneNumber(newParticipantDto.PhoneNumber);
            dbParticipant.TicketType = newParticipantDto.TicketType;

            await Repository.UpdateAsync(dbParticipant);
            return ObjectMapper.Map<Participant, ParticipantDto>(dbParticipant);
        }
    }
}
