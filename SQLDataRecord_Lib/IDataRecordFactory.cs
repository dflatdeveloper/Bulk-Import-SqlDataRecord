using Microsoft.Data.SqlClient.Server;
using System.Data;

namespace SQLDataRecord_Lib
{
    internal interface IDataRecordFactory
    {
        IDataRecord GetDataRecord(IList<SqlMetaData> meta);
    }
}