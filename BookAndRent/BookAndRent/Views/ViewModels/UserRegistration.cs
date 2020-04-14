﻿
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAndRent.Views.ViewModels
{
    public class UserRegistration
    {
        public int Id { get; set; }
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
        [Required(ErrorMessage = "Пожалуйста, введите пароль.")]
        public string Password { get; set; }
    }
}
