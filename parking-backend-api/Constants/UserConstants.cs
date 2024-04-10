using parking_backend_api.Models;

namespace parking_backend_api.Constants
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "jgomez", Password = "admin123", Rol = "Admin", EmailAddress = "jgomez@gmail.com", FirstName = "Jorge", LastName = "Gomez"},
            new UserModel() { Username = "elias", Password = "admin123", Rol = "Sales", EmailAddress = "elias@gmail.com", FirstName = "Elias", LastName = "Gonzalez"},
        };
    }
}
