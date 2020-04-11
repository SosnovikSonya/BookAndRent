using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public decimal CostPerNight { get; set; }
        public int SleepingPlaces { get; set; }
        public int RoomAmount { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Picture> Pictures { get; set; }
        public List<RentDate> AvailableDates { get; set; }
        public List<Contract> Contracts { get; set; }
        public int UserId { get; set; }
        public List<ApartmentFacility> ApartmentFacilities { get; set; }
        public bool IsDeleted { get; set; }
    }
}
