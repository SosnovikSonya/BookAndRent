using BookAndRent.Views.ViewModels.ApartmentModels;
using System.Collections.Generic;
using System.ComponentModel;


namespace BookAndRent.Views.ViewModels.UserModels
{
    public class AccountInfo
    {
        [DisplayName("Имя")]       
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Логин")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }

        public List<Contract> Contracts { get; set; }
        public List<AvailableApartmentInfo> Apartments { get; set; }
    }
}
