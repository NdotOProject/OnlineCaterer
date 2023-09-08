using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Application.Initialization;

namespace OnlineCaterer.Web.Views.Shared.Components.AboutPage
{
    [ViewComponent]
    public class AboutPage : ViewComponent
    {
        public class Data
        {
            public CompanyInfo Company { get; set; }
            public int CatererCount { get; set; }
            public int CustomerCount { get; set; }
            public int TransactionCount { get; set; }
        }

        public IViewComponentResult Invoke(Data model)
        {
            return View(model);
        }
    }
}
