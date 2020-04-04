using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository
{
    public class Contract
    {
        public int ContractId { get; set; }
        public User Renter { get; set; }
        public User Holder { get; set; }
        public int ApartmentId { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
