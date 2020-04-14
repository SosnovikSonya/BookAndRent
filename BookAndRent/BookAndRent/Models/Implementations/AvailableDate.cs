using BookAndRent.Models.Intefaces;
using System;

namespace BookAndRent.Models.Implementations
{
    public class AvailableDate : IAvailableDate
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }
}
