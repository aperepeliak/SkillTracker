using ST.BLL.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ST.WebUI.ViewModels
{
    public class ReportFormViewModel
    {
        [Display(Name = "Select Category")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }

        [Display(Name = "Select Skill")]
        public int SkillId { get; set; }
        public IEnumerable<SkillDto> Skills { get; set; }

        public IEnumerable<DeveloperDto> SelectedDevelopers { get; set; }
    }
}