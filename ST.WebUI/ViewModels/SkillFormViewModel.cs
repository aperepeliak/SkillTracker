using ST.BLL.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ST.WebUI.ViewModels
{
    public class SkillFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }

        public string Heading { get; set; }
        public string Action => Id == 0 ? "Create" : "Update";
    }
}