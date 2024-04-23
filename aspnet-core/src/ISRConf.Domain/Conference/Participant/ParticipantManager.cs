using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ISRConf.Conference.Participant
{
    public class ParticipantManager : DomainService
    {
        protected IRepository<Participant, Guid> ParticipantRepository { get; }

        public ParticipantManager(
            IRepository<Participant, Guid> patricipantRepository)
        {
            ParticipantRepository = patricipantRepository;
        }

        public virtual async Task<Participant> CrateParticipantAsync(
            string firstName,
            string surname,
            string emailAdress,
            string phoneNumber,
            TicketType ticketType)
        {
            var emailInUse = await ParticipantRepository.AnyAsync(dbParticipant => dbParticipant.EmailAdress == emailAdress);

            if (emailInUse)
            {
                throw new UserFriendlyException($"Participant with email adress: {emailAdress} already exists. Please choose different email address.");
            }

            var participant = new Participant(GuidGenerator.Create(), firstName, surname, emailAdress, phoneNumber, ticketType);
            return participant;
        }

        public virtual async Task ChangeParticipantEmailAdressAsync(Participant participant, string newEmailAdress)
        {
            var participantUsingNewEmailAdress = await ParticipantRepository.FirstOrDefaultAsync(dbParticipant => dbParticipant.EmailAdress == newEmailAdress);

            if (participantUsingNewEmailAdress != null && participantUsingNewEmailAdress.Id != participant.Id)
            {
                throw new UserFriendlyException($"Participant with email adress: {newEmailAdress} already exists. Please choose different email address.");
            }

            participant.SetEmailAdress(newEmailAdress);
        }
    }
}
