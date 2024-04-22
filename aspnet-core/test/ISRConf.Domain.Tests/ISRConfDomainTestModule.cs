using Volo.Abp.Modularity;

namespace ISRConf;

[DependsOn(
    typeof(ISRConfDomainModule),
    typeof(ISRConfTestBaseModule)
)]
public class ISRConfDomainTestModule : AbpModule
{

}
