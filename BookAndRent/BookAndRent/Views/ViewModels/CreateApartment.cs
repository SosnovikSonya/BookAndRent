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
        public string Address { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Название")]
        public string Title { get; set; }
        [DisplayName("Стоимость одной ночи")]
        public decimal CostPerNight { get; set; }
        [DisplayName("Количество спальных мест")]
        public int SleepingPlaces { get; set; }
        [DisplayName("Количество комнат")]
        public int RoomAmount { get; set; }
        public string Coordinates { get; set; }
    }
}
