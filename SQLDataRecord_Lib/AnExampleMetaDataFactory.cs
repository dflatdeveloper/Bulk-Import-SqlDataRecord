using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace SQLDataRecord_Lib
{
    internal class AnExampleMetaDataFactory(IServiceProvider sp) : ISqlMetaDataFactory
    {
        public SqlMetaData GetMetaData(string name, SqlDbType type)
        {
            return ActivatorUtilities.CreateInstance<SqlMetaData>(sp, name, type);
        }

        public SqlMetaData GetMetaData(string name, SqlDbType type, long maxLength)
        {
            return ActivatorUtilities.CreateInstance<SqlMetaData>(sp, name, type, maxLength);
        }
    }
}
