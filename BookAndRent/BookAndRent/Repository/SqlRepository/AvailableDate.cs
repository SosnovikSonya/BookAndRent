using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndRent.Repository.SqlRepository
{
    public class AvailableDate: ITable
    {
        [Column("AvailableDateId")]
        [Key()]
        public int Id { get; set; }
        public virtual Apartment Apartment { get; set; }
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
