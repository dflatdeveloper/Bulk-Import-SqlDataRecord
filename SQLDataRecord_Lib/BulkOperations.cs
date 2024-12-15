using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace SQLDataRecord_Lib
{
    public static class BulkOperations
    {
        public static IServiceCollection AddBulkServices(this IServiceCollection svc)
        {
            svc.AddScoped<IDbConnection>(sp =>
            {
                return ActivatorUtilities.CreateInstance<SqlConnection>(sp, sp.GetRequiredService<RepositorySettings>().ConnectionString);
            });

            svc.AddScoped<IADONetRepository, ADONetRepository>(sp =>
            {
                return ActivatorUtilities.CreateInstance<ADONetRepository>(sp, sp.GetRequiredService<IDbConnection>());
            });   

            svc.AddScoped<ISqlMetaDataFactory, AnExampleMetaDataFactory>();

            svc.AddTransient<IDataRecordFactory, AnExampleDataRecordFactory>();

            return svc;
        }

    }
}
