using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository.SqlRepository
{
    public class AvailableDate: ITable
    {
        [Column("AvailableDateId")]
        [Key()]
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
