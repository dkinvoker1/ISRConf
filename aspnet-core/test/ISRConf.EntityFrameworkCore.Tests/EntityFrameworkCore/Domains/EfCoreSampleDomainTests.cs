using ISRConf.Samples;
using Xunit;

namespace ISRConf.EntityFrameworkCore.Domains;

[Collection(ISRConfTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ISRConfEntityFrameworkCoreTestModule>
{

}
