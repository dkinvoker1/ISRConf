using Volo.Abp.Modularity;

namespace ISRConf;

[DependsOn(
    typeof(ISRConfApplicationModule),
    typeof(ISRConfDomainTestModule)
)]
public class ISRConfApplicationTestModule : AbpModule
{

}
