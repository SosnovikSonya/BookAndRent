using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Implementations
{
    public class Apartment : IApartment
    {
        public int ApartmentId { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public decimal CostPerNight { get; set; }
        public int SleepingPlaces { get; set; }
        public int RoomAmount { get; set; }
        public List<IComment> Comments { get; set; }
        public List<IFacility> Facilities { get; set; }
        public List<IPicture> Pictures { get; set; }
        public List<IRentDate> AvailableDates { get; set; }
        public List<IContract> Contracts { get; set; }
        public IUser HouseHolder { get; set; }
    }
}
