using System.ComponentModel.DataAnnotations;

namespace ISRConf.Conference.Participant
{
    public class CreateUpdateParticipantDto
    {
        [Required]
        [MaxLength(ParticipantConsts.MaxNameLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(ParticipantConsts.MaxNameLength)]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [MaxLength(ParticipantConsts.MaxEmailAdressLength)]
        [EmailAddress]
        public string EmailAdress { get; set; } = string.Empty;

        [Required]
        [MaxLength(ParticipantConsts.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public TicketType TicketType { get; set; } = TicketType.Normal;
    }
}
