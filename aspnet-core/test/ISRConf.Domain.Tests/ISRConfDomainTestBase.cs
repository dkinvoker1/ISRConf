using Volo.Abp.Modularity;

namespace ISRConf;

/* Inherit from this class for your domain layer tests. */
public abstract class ISRConfDomainTestBase<TStartupModule> : ISRConfTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
