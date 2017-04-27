using ST.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST.WebUI.Controllers
{
    public class ReportsController : Controller
    {      
        public void SaveReport(ReportDto dto)
        {
            dto.DateTime = DateTime.Now;
            var grid = new GridView()
            {
                DataSource = dto.Filters.Select(f => new
                {
                    CategoryId = f.CategoryId,
                    SkillId = f.SkillId,
                    Rating = f.Rating,
                    Comparer = f.Comparer
                })
            };
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachement; filename=ExportedTest.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);

            grid.RenderControl(htmlTextWriter);

            Response.Write(sw.ToString());
            Response.End();
        }
    }
}