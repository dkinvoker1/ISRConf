using NSubstitute;
using NSubstitute.Extensions;
using Shouldly;
using System;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;
using Xunit;

namespace ISRConf.Conference.Participant
{
    public class ParticipantManagerTests
    {
        private readonly IRepository<Participant, Guid> _fakeParticipantRepo;
        private readonly ParticipantManager _participantManager;
        private readonly Guid _participantId;
        private readonly Participant _participant;

        public ParticipantManagerTests()
        {
            _fakeParticipantRepo = Substitute.For<IRepository<Participant, Guid>>();
            _participantManager = new ParticipantManager(_fakeParticipantRepo);
            _participantId = Guid.NewGuid();
            _participant = new Participant(_participantId, "Adam", "Nowak", "adamnowak@gmail.com", "123123123", TicketType.Normal);
        }

        [Fact]
        public async Task Should_Create_Participant()
        {
            // Arrange

            _fakeParticipantRepo.AnyAsync(Arg.Any<Expression<Func<Participant, bool>>>()).ReturnsForAnyArgs(false);

            // Act

            var paricipant = await _participantManager.CrateParticipantAsync(_participant);

            //Assert

            paricipant.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Not_Create_Participant()
        {
            // Arrange

            _fakeParticipantRepo.AnyAsync(Arg.Any<Expression<Func<Participant,bool>>>()).ReturnsForAnyArgs(true);

            // Act & Assert
            await Assert.ThrowsAsync<UserFriendlyException>(async () =>
            {
                await _participantManager.CrateParticipantAsync(_participant);
            });
        }

        [Fact]
        public async Task Should_Change_Participant_Email()
        {
            // Arrange
            string newEmail = "new@email.com";
            _fakeParticipantRepo.FirstOrDefaultAsync(Arg.Any<Expression<Func<Participant, bool>>>()).ReturnsForAnyArgs(_participant);

            // Act

            await _participantManager.ChangeParticipantEmailAdressAsync(_participant, newEmail);

            //Assert

            _participant.EmailAdress.ShouldBe(newEmail);
        }

        [Fact]
        public async Task Should_Not_Change_Participant_Email()
        {
            // Arrange

            var otherParticipantId = Guid.NewGuid();
            var otherParticipant = new Participant(otherParticipantId, "Alina", "Nowak", "new@email.com", "123123123", TicketType.Normal);

            string newEmail = "adamnowak@gmail.com";
            _fakeParticipantRepo.FirstOrDefaultAsync(Arg.Any<Expression<Func<Participant, bool>>>()).ReturnsForAnyArgs(_participant);

            // Act & Assert
            await Assert.ThrowsAsync<UserFriendlyException>(async () =>
            {
                await _participantManager.ChangeParticipantEmailAdressAsync(otherParticipant, newEmail);
            });
        }
    }
}
