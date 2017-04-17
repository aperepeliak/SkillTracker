using ST.BLL.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ST.WebUI.ViewModels
{
    public class SkillRatingFormViewModel
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<SkillDto> Skills { get; set; }
        public int SkillId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public SkillRatingFormViewModel()
        {
            Skills = new List<SkillDto>();
        }
    }
}