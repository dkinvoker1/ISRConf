using ISRConf.Samples;
using Xunit;

namespace ISRConf.EntityFrameworkCore.Applications;

[Collection(ISRConfTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ISRConfEntityFrameworkCoreTestModule>
{

}
