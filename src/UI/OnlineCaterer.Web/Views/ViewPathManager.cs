namespace OnlineCaterer.Web.Views;

public class ViewPathManager
{
    #region Auth
    private const string AUTH_DIR = "/Auth";

	private const string AUTH_BOOKING_DIR = $"{AUTH_DIR}/Booking";
	public const string BookingIndex = $"{AUTH_BOOKING_DIR}/BookingIndex";
	public const string BookingDetails = $"{AUTH_BOOKING_DIR}/BookingDetails";

	private const string AUTH_CATERER_DIR = $"{AUTH_DIR}/Caterer";

	public const string CreateFood = $"{AUTH_CATERER_DIR}/Food/CreateFood";

	private const string AUTH_CATERER_FOODTYPE_DIR = $"{AUTH_CATERER_DIR}/FoodType";
	public const string CreateFoodType = $"{AUTH_CATERER_FOODTYPE_DIR}/CreateFoodType";
	public const string FoodTypeIndex = $"{AUTH_CATERER_FOODTYPE_DIR}/FoodTypeIndex";
	public const string UpdateFoodType = $"{AUTH_CATERER_FOODTYPE_DIR}/UpdateFoodType";

	private const string AUTH_CATERER_RESPONSEMESSAGE_DIR = $"{AUTH_CATERER_DIR}/ResponseMessage";
	public const string CreateMessage = $"{AUTH_CATERER_RESPONSEMESSAGE_DIR}/CreateMessage";
	public const string DeleteMessage = $"{AUTH_CATERER_RESPONSEMESSAGE_DIR}/DeleteMessage";
	public const string ListMessage = $"{AUTH_CATERER_RESPONSEMESSAGE_DIR}/ListMessage";
	public const string UpdateMessage = $"{AUTH_CATERER_RESPONSEMESSAGE_DIR}/UpdateMessage";

	private const string AUTH_CUSTOMER_DIR = $"{AUTH_DIR}/Customer";
	public const string CreateBooking = $"{AUTH_CUSTOMER_DIR}/Booking/CreateBooking";

	public const string CreatePlace = $"{AUTH_DIR}/Place/CreatePlace";
    #endregion

    #region Caterer
    private const string CATERER_DIR = "/Caterer";
	public const string CatererRegister = $"{CATERER_DIR}/CatererRegister";
	public const string ListCaterer = $"{CATERER_DIR}/ListCaterer";
    #endregion

    #region Customer
    public const string SearchPage = $"/Customer/SearchPage";
    #endregion

    #region Food
    private const string FOOD_DIR = "/Food";
	public const string FoodDetails = $"{FOOD_DIR}/FoodDetails";
	public const string FoodIndex = $"{FOOD_DIR}/FoodIndex";
    #endregion

    #region Home
    private const string HOME_DIR = "/Home";
	public const string About = $"{HOME_DIR}/About";
	public const string Index = $"{HOME_DIR}/Index";
	public const string Privacy = $"{HOME_DIR}/Privacy";
    #endregion

    #region Place
    public const string PlaceIndex = "/Place/PlaceIndex";
    #endregion

}
