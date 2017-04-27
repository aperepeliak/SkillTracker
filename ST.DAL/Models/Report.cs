using System;
using System.Collections.Generic;

namespace ST.DAL.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        public string ManagerId { get; set; }
        public Manager Manager { get; set; }

        public ICollection<ReportFilter> ReportFilters { get; set; }
        public ICollection<Developer> SelectedDevelopers { get; set; }

        public Report()
        {
            ReportFilters = new List<ReportFilter>();
            SelectedDevelopers = new List<Developer>();
        }
    }
}
