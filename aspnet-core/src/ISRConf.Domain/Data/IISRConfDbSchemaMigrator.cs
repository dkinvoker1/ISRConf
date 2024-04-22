using System.Threading.Tasks;

namespace ISRConf.Data;

public interface IISRConfDbSchemaMigrator
{
    Task MigrateAsync();
}
