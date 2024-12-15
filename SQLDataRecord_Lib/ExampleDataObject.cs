using Microsoft.Data.SqlClient.Server;
using System.Data;

namespace SQLDataRecord_Lib
{
    public class ExampleDataObject : IDataRecordBuilder
    {
        private readonly ISqlMetaDataFactory _metaFactory;
        private readonly IDataRecordFactory _dataFactory;
        internal ExampleDataObject (ISqlMetaDataFactory metaFactory, IDataRecordFactory dataFactory)
        {
            _metaFactory = metaFactory;
            _dataFactory = dataFactory;
        }

        public int ID { get; set; }
        public string? Name { get; set; }

        IDataRecord IDataRecordBuilder.GetDataRecord() {

            IList<SqlMetaData> meta = [];

            meta.Add(_metaFactory.GetMetaData(nameof(ID), SqlDbType.Int));

            meta.Add(_metaFactory.GetMetaData(nameof(Name), SqlDbType.VarChar, -1)); //Varchar(MAX)
                       
            return _dataFactory.GetDataRecord(meta); 
        
        
        }
        
    }
}
