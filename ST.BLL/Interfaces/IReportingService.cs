using ClosedXML.Excel;
using ST.BLL.DTOs;

namespace ST.BLL.Interfaces
{
    public interface IReportingService
    {
        XLWorkbook GenerateExcelReport(ReportDto reportDto);
    }
}
