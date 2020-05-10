using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BookAndRent.Views.ViewModels.ApartmentModels
{
    public class SearchModel
    {
        [DisplayName("Местоположение")]
        [Required(ErrorMessage = "Пожалуйста, введите адрес")]
        public string Address { get; set; }

        [DisplayName("Количество гостей")]
        [Required(ErrorMessage = "Пожалуйста, введите количество гостей")]
        public int GuestsNumber { get; set; }

        [DisplayName("Прибытие")]
        [Required(ErrorMessage = "Пожалуйста, введите дату приезда")]
        public DateTime CheckIn { get; set; }

        [DisplayName("Выезд")]
        [Required(ErrorMessage = "Пожалуйста, введите дату отъезда")]
        public DateTime CheckOut { get; set; }

    }
}
