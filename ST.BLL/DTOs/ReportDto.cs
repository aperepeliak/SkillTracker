using System;
using System.Collections.Generic;

namespace ST.BLL.DTOs
{
    public class ReportDto
    {
        public string   Name     { get; set; }
        public DateTime DateTime { get; }

        public IEnumerable<DeveloperDto> SearchResults { get; set; }

        public ReportDto()
        {
            DateTime = DateTime.Now;
            SearchResults = new List<DeveloperDto>();
        }
    }
}
