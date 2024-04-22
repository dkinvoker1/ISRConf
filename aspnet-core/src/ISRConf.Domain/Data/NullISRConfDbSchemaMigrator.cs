using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ISRConf.Data;

/* This is used if database provider does't define
 * IISRConfDbSchemaMigrator implementation.
 */
public class NullISRConfDbSchemaMigrator : IISRConfDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
