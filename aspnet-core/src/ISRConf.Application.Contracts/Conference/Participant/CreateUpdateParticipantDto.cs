using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace ISRConf.Conference.Participant
{
    public class CreateUpdateParticipantDto
    {
        [Required]
        [DynamicStringLength(typeof(ParticipantConsts), nameof(ParticipantConsts.MaxNameLength))]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [DynamicStringLength(typeof(ParticipantConsts), nameof(ParticipantConsts.MaxNameLength))]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [DynamicStringLength(typeof(ParticipantConsts), nameof(ParticipantConsts.MaxEmailAdressLength))]
        [EmailAddress]
        public string EmailAdress { get; set; } = string.Empty;

        [Required]
        [DynamicStringLength(typeof(ParticipantConsts), nameof(ParticipantConsts.MaxPhoneNumberLength))]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public TicketType TicketType { get; set; } = TicketType.Normal;
    }
}
