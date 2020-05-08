
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAndRent.Views.ViewModels.UserModels
{
    public class LoginRequest
    {
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
