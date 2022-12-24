using System.Windows.Controls;

namespace BrandManagerV1
{
    public interface IDataAccess
    {
        void CreateRecord(Brand brand);
        void ReadRecords(DataGrid dataGrid);
        void UpdateRecord(Brand brand);
        void DeleteRecord(Brand brand);

    }
}
