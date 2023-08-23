namespace OnlineCaterer.Web.Views.Shared.Layout;

public static class ManageLayoutComponents
{
    #region dir
    private const string LAYOUT_DIR = "./Layout";

    private const string LAYOUT_COMPONENTS_DIR = $"{LAYOUT_DIR}/Components";

    private const string HEADER_COMPONENT_DIR = $"{LAYOUT_COMPONENTS_DIR}/Header";

    private const string HEADER_PARTIALS_DIR = $"{HEADER_COMPONENT_DIR}/Partials";

    #endregion

    #region cshtml
    public const string Layout = $"{LAYOUT_DIR}/_Layout";

    public const string CatererHeader = $"{HEADER_COMPONENT_DIR}/_CatererHeaderPartial";

    public const string CustomerHeader = $"{HEADER_COMPONENT_DIR}/_CustomerHeaderPartial";

    public const string HeaderBackground = $"{HEADER_PARTIALS_DIR}/_HeaderBackground";

    public const string NavLeft = $"{HEADER_PARTIALS_DIR}/_NavLeft";

    public const string SelectedOptionBox = $"{HEADER_PARTIALS_DIR}/_SelectedOptionBox";

    public const string SliderPartial = $"{HEADER_PARTIALS_DIR}/_SliderPartial";

    #endregion

}
