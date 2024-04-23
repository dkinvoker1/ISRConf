using System;
using Volo.Abp.Application.Dtos;

namespace ISRConf.Conference.Participant
{
    public class ParticipantDto : AuditedEntityDto<Guid>
    {
        public string FirstName { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public string EmailAdress { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public TicketType TicketType { get; set; }
    }
}
