using Microsoft.Data.SqlClient;
using System.Data;

namespace SQLDataRecord_Lib
{
    public class ADONetRepository (IDbConnection _connection) : IADONetRepository
    {
        public void BulkInsertPayload<T>(IEnumerable<T> payloads) where T : class, IDataRecordBuilder
        {
            //create data record

            List<IDataRecord> sqlDataRecords = [];


            // Create a list of SqlDataRecord objects from your list of entities here
            payloads
                .ToList()
                .ForEach(payload =>
                {

                    sqlDataRecords.Add(payload.GetDataRecord());

                });

            //Get the connection somehow (EF, ADO.net, ...)

            using SqlConnection? connection = _connection as SqlConnection;

            if (connection == null)
                return;

            //using var connection = (SqlConnection)Database.GetDbConnection();

            //using var connection = new SqlConnection("ConnectionStringValueFromConfig"); //Not the DI way

            using var command = connection.CreateCommand();

            command.Connection = connection;

            connection.Open();

            command.CommandText = "usp_NameOfSomeBulkInsertSProc";

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("ExampleParam", SqlDbType.Structured)
            {
                Value = sqlDataRecords,
                TypeName = "dbo.NameOfUDTableType_TT"
            });

            command.ExecuteNonQuery();
        }
    }
}
