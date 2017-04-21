using System.Collections.Generic;

namespace ST.WebUI.ViewModels
{
    public class DevelopersViewModel
    {
        public string SearchTerm { get; set; }
        public IEnumerable<DeveloperViewModel> Developers { get; set; }
    }
}