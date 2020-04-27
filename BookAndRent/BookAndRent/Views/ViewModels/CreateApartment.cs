using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Views.ViewModels
{
    public class CreateApartment
    {
        [DisplayName("Адрес")]
        [Required(ErrorMessage = "Пожалуйста, введите адрес")]
        public string Address { get; set; }
        [DisplayName("Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите краткое описание")]
        public string Description { get; set; }
        [DisplayName("Название")]
        [Required(ErrorMessage = "Пожалуйста, введите краткое название")]
        public string Title { get; set; }
        // public string Coordinates { get; set; }
        [DisplayName("Стоимость одной ночи")]
        [Required(ErrorMessage = "Пожалуйста, введите стоимость одной ночи")]
        public decimal CostPerNight { get; set; }
        [DisplayName("Количество спальных мест")]
        [Required(ErrorMessage = "Пожалуйста, введите количество спальных мест")]
        public int SleepingPlaces { get; set; }
        [DisplayName("Количество комнат")]
        [Required(ErrorMessage = "Пожалуйста, введите количество комнат")]
        public int RoomAmount { get; set; }
    }
}
