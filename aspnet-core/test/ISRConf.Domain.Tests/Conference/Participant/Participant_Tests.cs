using Shouldly;
using System;
using Xunit;

namespace ISRConf.Conference.Participant
{
    public class Participant_Tests
    {

        private readonly Guid _participantId;

        public Participant_Tests()
        {
            _participantId = Guid.NewGuid();
        }

        [Fact]
        public void Should_Create_Valid_Participant()
        {
            var participant = new Participant(_participantId, "Adam", "Nowak", "adamnowak@gmail.com", "123123123", TicketType.Normal);
            
            participant.ShouldNotBeNull();
        }

        [Fact]
        public void Should_Not_Create_Invalid_Participant()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var participant = new Participant(_participantId, "    ", "Nowak", "adamnowak@gmail.com", "123123123", TicketType.Normal);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var participant = new Participant(_participantId, "Adam", " ", "adamnowak@gmail.com", "123123123", TicketType.Normal);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var participant = new Participant(_participantId, "Adam", "Nowak", "", "123123123", TicketType.Normal);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var participant = new Participant(_participantId, "Adam", "Nowak", "adamnowak@gmail.com", "     ", TicketType.Normal);
            });
        }
    }
}
