using ISRConf.Conference.Participant;
using Xunit;

namespace ISRConf.EntityFrameworkCore.Applications.Conference.Participant
{
    [Collection(ISRConfTestConsts.CollectionDefinitionName)]
    public class EfCoreParticipantAppServiceTests : ParticipantAppServiceTests<ISRConfEntityFrameworkCoreTestModule>
    {

    }
}
