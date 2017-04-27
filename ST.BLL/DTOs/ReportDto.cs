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

        public IEnumerable<ReportFilterDto> Filters { get; set; }
        public IEnumerable<DeveloperDto> SearchResults { get; set; }
    }
}
