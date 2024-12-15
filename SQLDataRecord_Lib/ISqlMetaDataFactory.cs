using Microsoft.Data.SqlClient.Server;
using System.Data;

namespace SQLDataRecord_Lib
{
    internal interface ISqlMetaDataFactory
    {
        SqlMetaData GetMetaData(string name, SqlDbType type);
        SqlMetaData GetMetaData(string name, SqlDbType type, long maxLength);

    }
}