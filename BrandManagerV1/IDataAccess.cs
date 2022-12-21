using System.Collections.Generic;

namespace BrandManagerV1
{
    public interface IDataAccess
    {
        void CreateRecord(string brandName, bool isEnabled);
        List<Brand> ReadRecords();
        void UpdateRecord(int id, string brandName, bool isEnabled);
        void DeleteRecord(int id);

    }
}
