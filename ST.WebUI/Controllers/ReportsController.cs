using ClosedXML.Excel;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using System;
using System.IO;
using System.Web.Mvc;

namespace ST.WebUI.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportingService _reporting;

        public ReportsController(IReportingService reporting)
        {
            _reporting = reporting;
        }

        public ActionResult SaveReport(ReportDto reportDto)
        {
            XLWorkbook workbook = _reporting.GenerateExcelReport(reportDto);

            string handle = Guid.NewGuid().ToString();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.Position = 0;
                TempData[handle] = memoryStream.ToArray();
            }

            return new JsonResult()
            {
                Data = new { FileGuid = handle, FileName = $"{reportDto.Name}.xlsx" }
            };
        }

        public ActionResult Download(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                byte[] data = TempData[fileGuid] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            
            return new EmptyResult();         
        }
    }
}