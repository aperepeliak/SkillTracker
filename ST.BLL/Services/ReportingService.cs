using ClosedXML.Excel;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;

namespace ST.BLL.Services
{
    public class ReportingService : IReportingService
    {
        public XLWorkbook GenerateExcelReport(ReportDto reportDto)
        {
            XLWorkbook workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("SearchResults");

            worksheet.Columns().Width = 20;

            worksheet.Cell("A1").SetValue("Report generated:");
            worksheet.Cell("B1").SetValue(reportDto.DateTime);

            worksheet.Cell("A1").Style.Font.SetBold();
            worksheet.Cell("B1").Style.Font.SetItalic();


            worksheet.Cell("A2").SetValue("Report name:");
            worksheet.Cell("B2").SetValue(reportDto.Name);

            worksheet.Cell("A2").Style.Font.SetBold();
            worksheet.Cell("B2").Style.Font.SetItalic();

            worksheet.Cell("A4").SetValue("Email");
            worksheet.Cell("B4").SetValue("First Name");
            worksheet.Cell("C4").SetValue("Last Name");
            worksheet.Cell("D4").SetValue("Skill Category");
            worksheet.Cell("E4").SetValue("Skill Name");
            worksheet.Cell("F4").SetValue("Skill Rating");

            worksheet.Range("A4:F4").Style.Border.BottomBorder = XLBorderStyleValues.Medium;
            worksheet.Range("A4:F4").Style.Font.SetBold();

            int x = 5;
            int y = 1;
            foreach (var developer in reportDto.SearchResults)
            {
                foreach (var category in developer.SkillRatings)
                {
                    foreach (var skillRating in category.Value)
                    {
                        worksheet.Cell(x, y).SetValue(developer.Email); y++;
                        worksheet.Cell(x, y).SetValue(developer.FirstName); y++;
                        worksheet.Cell(x, y).SetValue(developer.LastName); y++;
                        worksheet.Cell(x, y).SetValue(skillRating.CategoryName); y++;
                        worksheet.Cell(x, y).SetValue(skillRating.SkillName); y++;
                        worksheet.Cell(x, y).SetValue(skillRating.Rating); y++;
                        x++; y = 1;
                    }
                }
            }

            return workbook;
        }
    }
}
