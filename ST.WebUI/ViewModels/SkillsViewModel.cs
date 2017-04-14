using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.WebUI.ViewModels
{
    public class SkillsViewModel
    {
        public IEnumerable<SkillDto> Skills { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
        public string SelectedCategoryName { get; set; }
        public int SelectedCategoryId { get; set; }
    }
}