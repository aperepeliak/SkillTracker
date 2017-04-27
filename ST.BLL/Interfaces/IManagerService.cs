using ST.BLL.DTOs;

namespace ST.BLL.Interfaces
{
    public interface IManagerService
    {
        void SaveReport(string managerId, ReportDto dto);
    }
}
