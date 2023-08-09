
namespace OnlineCaterer.Application.Initialization;

public class Initialization
{
    public static List<Role> Roles => new(new Role[]
    {
        new Role
        {
            Name = ConstantsRoles.Caterer,
            NormalizedName = ConstantsRoles.Caterer.ToUpper(),
        },
        new Role
        {
            Name = ConstantsRoles.Customer,
            NormalizedName = ConstantsRoles.Customer.ToUpper(),
        },
    });

    public static List<User> Users => new(new User[]
    {
        new User
        {
            Roles = new List<string>(new string[]
            {
                ConstantsRoles.Caterer,
            }),
            CatererInfo = new Domain.Entities.Caterer
            {
                Name = "Aptech Food",
                Address = "19 Le Thanh Nghi, Hai Ba Trung, Ha Noi, Viet Nam",
            },
            Email = "aptech.ltn.hn.vn@aptech.vn",
            PhoneNumber = "0987654321",
            UserName = "aptech",
            Password = "123456",
        },
        new User
        {
            Roles = new List<string>(new string[]
            {
                ConstantsRoles.Customer,
            }),
            CustomerInfo = new Domain.Entities.Customer
            {
                Name = "Tom Holland",
                Address = "Ha Noi, Viet Nam",
            },
            Email = "tom.actor@gmail.com",
            UserName = "user1",
            Password = "123456",
        }
    });
}
