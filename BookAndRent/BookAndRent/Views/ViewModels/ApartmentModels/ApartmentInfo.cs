using System.Collections.Generic;
using System.ComponentModel;
using BookAndRent.Views.ViewModels.UserModels;


namespace BookAndRent.Views.ViewModels.ApartmentModels
{
    public class ApartmentInfo
    {
        public int ApartmentId { get; set; }

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
        [DisplayName("Фотографии")]
        public List<ApartmentPicture> Pictures { get; set; }
        [DisplayName("Дополнительные удобства")]
        public List<Facility> Facilities { get; set; }
        [DisplayName("Отзывы")]
        public List<Comment> Comments { get; set; }
        public string Coordinates { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}
