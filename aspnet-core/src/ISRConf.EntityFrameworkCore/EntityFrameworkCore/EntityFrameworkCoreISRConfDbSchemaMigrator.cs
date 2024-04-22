using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ISRConf.Data;
using Volo.Abp.DependencyInjection;

namespace ISRConf.EntityFrameworkCore;

public class EntityFrameworkCoreISRConfDbSchemaMigrator
    : IISRConfDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreISRConfDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ISRConfDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ISRConfDbContext>()
            .Database
            .MigrateAsync();
    }
}
