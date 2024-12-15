
namespace SQLDataRecord_Lib
{
    public interface IADONetRepository
    {
        void BulkInsertPayload<T>(IEnumerable<T> payloads) where T : class, IDataRecordBuilder;
    }
}