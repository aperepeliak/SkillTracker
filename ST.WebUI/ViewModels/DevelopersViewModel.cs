using System.Collections.Generic;
using X.PagedList;

namespace ST.WebUI.ViewModels
{
    public class DevelopersViewModel
    {
        public string SearchTerm { get; set; }
        public IPagedList<DeveloperViewModel> Developers { get; set; }
    }
}