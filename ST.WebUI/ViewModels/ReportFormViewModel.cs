using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.WebUI.ViewModels
{
    public class ReportFormViewModel
    {

        public IEnumerable<DeveloperDto> SelectedDevelopers { get; set; }
    }
}