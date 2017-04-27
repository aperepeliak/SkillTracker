using ST.BLL.DTOs;
using System;
using System.Collections.Generic;

namespace ST.WebUI.ViewModels
{
    public class ReportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerId { get; set; }

        public DateTime DateTime { get; set; }

        public IEnumerable<ReportFilterDto> Filters { get; set; }
        public IEnumerable<DeveloperViewModel> SearchResults { get; set; }
    }
}