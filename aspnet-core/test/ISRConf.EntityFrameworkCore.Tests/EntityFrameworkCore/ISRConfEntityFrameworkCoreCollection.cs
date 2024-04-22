using Xunit;

namespace ISRConf.EntityFrameworkCore;

[CollectionDefinition(ISRConfTestConsts.CollectionDefinitionName)]
public class ISRConfEntityFrameworkCoreCollection : ICollectionFixture<ISRConfEntityFrameworkCoreFixture>
{

}
