
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAndRent.Views.ViewModels.UserModels
{
    public class UserRegistration
    {

        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
