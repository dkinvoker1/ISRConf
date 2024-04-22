using ISRConf.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ISRConf.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ISRConfEntityFrameworkCoreModule),
    typeof(ISRConfApplicationContractsModule)
    )]
public class ISRConfDbMigratorModule : AbpModule
{
}
