using System;
using System.Collections.Generic;

namespace ST.BLL.DTOs
{
    public class ReportDto
    {
        public int Id           { get; set; }
        public string Name      { get; set; }
        public string ManagerId { get; set; }

        public DateTime DateTime { get; set; }

        public IEnumerable<ReportFilterDto> ReportFilters { get; set; }
        public IEnumerable<DeveloperDto> SelectedDevelopers { get; set; }
    }
}
