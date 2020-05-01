using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndRent.Repository.SqlRepository
{
    public class Apartment: ITable
    {
        [Column("ApartmentId")]
        [Key()]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public decimal CostPerNight { get; set; }
        public int SleepingPlaces { get; set; }
        public int RoomAmount { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Picture> Pictures { get; set; }
        public virtual List<AvailableDate> AvailableDates { get; set; }
        public virtual List<Contract> Contracts { get; set; }
        public virtual User User { get; set; }
        public Facility? Facilities { get; set; }
        public bool IsDeleted { get; set; }
    }
}
