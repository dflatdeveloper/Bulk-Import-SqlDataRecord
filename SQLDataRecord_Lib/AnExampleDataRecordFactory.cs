using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace SQLDataRecord_Lib
{
    public class AnExampleDataRecordFactory(IServiceProvider sp) : IDataRecordFactory
    {
        public IDataRecord GetDataRecord(IList<SqlMetaData> meta)
        {
            return ActivatorUtilities.CreateInstance<IDataRecord>(sp, [.. meta]);
        }
    }
}
