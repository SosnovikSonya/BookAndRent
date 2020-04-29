using BookAndRent.Models.Intefaces;
using System;

namespace BookAndRent.Models.Implementations
{
    public class Contract : IContract
    {
        public int Id { get; set; }
        public int RenterId { get; set; }
        public int HolderId { get; set; }
        public int ApartmentId { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Amount { get; set; }
    }
}
