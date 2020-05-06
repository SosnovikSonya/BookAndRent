
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAndRent.Views.ViewModels.UserModels
{
    public class UserRegistration
    {

        [DisplayName("Имя")]
        [Required(ErrorMessage = "Пожалуйста, введите имя.")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Пожалуйста, введите фамилию.")]       
        public string LastName { get; set; }
        [DisplayName("Логин")]
        [Required(ErrorMessage = "Пожалуйста, введите логин.")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пожалуйста, введите пароль.")]
        public string Password { get; set; }
    }
}
