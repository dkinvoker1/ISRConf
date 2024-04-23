using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ISRConf.Conference.Participant
{
    public class Participant : AuditedAggregateRoot<Guid>
    {
        public virtual string FirstName { get; protected set; }

        public virtual string Surname { get; protected set; }

        public virtual string EmailAdress { get; protected set; }

        public virtual string PhoneNumber { get; protected set; }

        public virtual TicketType TicketType { get; set; }

        protected Participant() { }

        public Participant(
            Guid id,
            string firstName,
            string surname,
            string emailAdress,
            string phoneNumber,
            TicketType ticketType) : base(id)
        {
            SetFirstName(firstName);
            SetSurname(surname);
            SetEmailAdress(emailAdress);
            SetPhoneNumber(phoneNumber);
            TicketType = ticketType;
        }

        public virtual void SetFirstName(string firstName)
        {
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName), ParticipantConsts.MaxNameLength);
            FirstName = firstName;
        }

        public virtual void SetSurname(string surname) { 
            Check.NotNullOrWhiteSpace(surname, nameof(Surname), ParticipantConsts.MaxNameLength);
            Surname = surname;
        }

        public virtual void SetEmailAdress(string emailAdress)
        {
            Check.NotNullOrWhiteSpace(emailAdress, nameof(EmailAdress), ParticipantConsts.MaxEmailAdressLength);
            EmailAdress = emailAdress;
        }

        public virtual void SetPhoneNumber(string phoneNumber)
        {
            Check.NotNullOrWhiteSpace(phoneNumber,nameof(PhoneNumber), ParticipantConsts.MaxPhoneNumberLength);
            PhoneNumber = phoneNumber;
        }
    }
}
