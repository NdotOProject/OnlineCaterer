namespace OnlineCaterer.Web.Views.Shared.Layout;

public static class ManageLayoutComponents
{
    #region dir
    private const string VIEWS_SHARED_ROOT = "./";

    private const string AREAS_ROOT = "/Views/Shared";

    private const string LAYOUT_DIR = "Layout";

    private const string LAYOUT_COMPONENTS_DIR = $"{VIEWS_SHARED_ROOT}/{LAYOUT_DIR}/Components";

    private const string HEADER_COMPONENT_DIR = $"{LAYOUT_COMPONENTS_DIR}/Header";

    private const string FOOTER_COMPONENT_DIR = $"{LAYOUT_COMPONENTS_DIR}/Footer";

    private const string HEADER_PARTIALS_DIR = $"{HEADER_COMPONENT_DIR}/Partials";

    private const string SIDE_BAR_DIR = $"{LAYOUT_COMPONENTS_DIR}/SideBar";
    #endregion

    #region cshtml
    private const string LAYOUT_CSHTML = "_Layout";

    public const string AreasLayout = $"{AREAS_ROOT}/{LAYOUT_DIR}/{LAYOUT_CSHTML}";

    public const string Layout = $"{LAYOUT_DIR}/{LAYOUT_CSHTML}";

    public const string CatererHeader = $"{HEADER_COMPONENT_DIR}/_CatererHeaderPartial";

    public const string CustomerHeader = $"{HEADER_COMPONENT_DIR}/_CustomerHeader";

    public const string NavBrand = $"{HEADER_PARTIALS_DIR}/_NavBrand";

    public const string CustomerMiddleNav = $"{HEADER_PARTIALS_DIR}/_CustomerMiddleNav";

    public const string HeaderBackground = $"{HEADER_PARTIALS_DIR}/_HeaderBackground";

    public const string NavLeft = $"{HEADER_PARTIALS_DIR}/_NavLeft";

    public const string SelectedOptionBox = $"{HEADER_PARTIALS_DIR}/_SelectedOptionBox";

    public const string SliderPartial = $"{HEADER_PARTIALS_DIR}/_SliderPartial";

    public const string FooterPartial = $"{FOOTER_COMPONENT_DIR}/_FooterPartial";

	public const string SideBarLeft = $"{SIDE_BAR_DIR}/SideBarLeft";

	public const string SideBarRight = $"{SIDE_BAR_DIR}/SideBarRight";

	#endregion

}
