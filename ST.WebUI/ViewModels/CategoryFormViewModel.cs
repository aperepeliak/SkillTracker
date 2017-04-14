using System.ComponentModel.DataAnnotations;

namespace ST.WebUI.ViewModels
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Heading { get; set; }
        public string Action => Id == 0 ? "Create" : "Update";
    }
}