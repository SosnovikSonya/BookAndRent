using System;

namespace BookAndRent.Views.ViewModels.ApartmentModels
{
    public class AvailableDates
    {
        public int ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
