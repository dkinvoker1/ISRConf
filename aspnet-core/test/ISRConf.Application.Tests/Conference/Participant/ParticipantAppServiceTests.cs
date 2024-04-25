using Shouldly;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Modularity;
using Xunit;

namespace ISRConf.Conference.Participant
{
    public abstract class ParticipantAppServiceTests<TStartupModule> : ISRConfApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IParticipantAppService _participantAppService;

        protected ParticipantAppServiceTests()
        {
            _participantAppService = GetRequiredService<IParticipantAppService>();
        }

        [Fact]
        public async Task Should_Create_Participant()
        {
            //Assert 
            var createParticipantDto = new CreateUpdateParticipantDto { FirstName = "Zosia", Surname = "Kowalska", EmailAdress = "zosiakowalska@gmail.com", PhoneNumber = "123123123", TicketType = TicketType.Normal };

            //Act
            var participantDto = await _participantAppService.CreateAsync(createParticipantDto);

            //Assert
            participantDto.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Not_Create_Participant()
        {
            //Assert 
            var createParticipantDto = new CreateUpdateParticipantDto { FirstName = "Zosia", Surname = "Kowalska", EmailAdress = "alannowak@gmail.com", PhoneNumber = "123123123", TicketType = TicketType.Normal };

            //Act && Assert
            await Assert.ThrowsAsync<UserFriendlyException>(async () =>
            {
                var participantDto = await _participantAppService.CreateAsync(createParticipantDto);
            });
        }

        [Fact]
        public async Task Should_Update_Participant()
        {
            //Assert 
            var createParticipantDto = new CreateUpdateParticipantDto { FirstName = "Zosia", Surname = "Kowalska", EmailAdress = "zosiakowalska@gmail.com", PhoneNumber = "123123123", TicketType = TicketType.Normal };

            //Act
            var participantDto = await _participantAppService.UpdateAsync(ISRConfTestConsts.testGuid1, createParticipantDto);

            //Assert
            participantDto.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Not_Update_Participant()
        {
            //Assert 
            var createParticipantDto = new CreateUpdateParticipantDto { FirstName = "Zosia", Surname = "Kowalska", EmailAdress = "alannowak2@gmail.com", PhoneNumber = "123123123", TicketType = TicketType.Normal };

            //Act && Assert
            await Assert.ThrowsAsync<UserFriendlyException>(async () =>
            {
                var participantDto = await _participantAppService.UpdateAsync(ISRConfTestConsts.testGuid1, createParticipantDto);
            });
        }
    }
}
