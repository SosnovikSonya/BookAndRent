
using System.ComponentModel;


namespace BookAndRent.Views.ViewModels.ApartmentModels
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
