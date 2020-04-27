
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAndRent.Views.ViewModels
{
    public class LoginRequest
    {
        [DisplayName("Логин")]
        [Required(ErrorMessage = "Пожалуйста, введите логин.")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пожалуйста, введите пароль.")]
        public string Password { get; set; }
    }
}
