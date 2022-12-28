using System.Collections.Generic;

namespace BrandManagerV1
{
    public interface IDataAccess
    {
        void CreateRecord(Brand brand);
        List<Brand> ReadRecords();
        void UpdateRecord(Brand brand);
        void DeleteRecord(int id);
        void CreateTableIfNotExists(string tableName);
    }
}