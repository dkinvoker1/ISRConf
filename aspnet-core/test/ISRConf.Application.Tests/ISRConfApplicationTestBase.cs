using Volo.Abp.Modularity;

namespace ISRConf;

public abstract class ISRConfApplicationTestBase<TStartupModule> : ISRConfTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
