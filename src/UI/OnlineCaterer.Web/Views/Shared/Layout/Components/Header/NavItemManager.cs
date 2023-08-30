using OnlineCaterer.Web.Models;

namespace OnlineCaterer.Web.Views.Shared.Layout.Components.Header
{
    public class NavItemManager
    {
        private static readonly ViewInfo _homePage = new()
        {
            AspPage = ViewPathManager.Index,
            PageTitle = "Home Page",
            ShowTitle = "Home"
        };

        private static readonly ViewInfo _listCatererPage = new()
        {
            AspPage = ViewPathManager.ListCaterer,
            PageTitle = "Caterer List",
            ShowTitle = "Caterers"
        };

        private static readonly ViewInfo _foodMenuPage = new()
        {
            AspPage = ViewPathManager.FoodIndex,
            PageTitle = "Food List",
            ShowTitle = "Menu"
        };

        private static readonly ViewInfo _aboutPage = new()
        {
            AspPage = ViewPathManager.About,
            PageTitle = "About Online Caterer",
            ShowTitle = "About"
        };

        public static ViewInfo HomePage { get { return _homePage; } }

        public static ViewInfo ListCatererPage { get { return _listCatererPage; } }

        public static ViewInfo FoodMenuPage { get { return _foodMenuPage; } }

        public static ViewInfo AboutPage { get { return _aboutPage; } }

        public static List<ViewInfo> ViewModels
        {
            get
            {
                return new List<ViewInfo>
                {
                    HomePage, ListCatererPage, FoodMenuPage, AboutPage
                };
            }
        }
    }
}
