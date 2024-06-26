﻿using System;
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

        public virtual async Task<Participant> CrateParticipantAsync(Participant participant)
        {
            var emailInUse = await ParticipantRepository.AnyAsync(dbParticipant => dbParticipant.EmailAdress == participant.EmailAdress);

            if (emailInUse)
            {
                throw new UserFriendlyException($"Participant with email adress: {participant.EmailAdress} already exists. Please choose different email address.");
            }

            return new Participant(Guid.NewGuid(), participant);
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
