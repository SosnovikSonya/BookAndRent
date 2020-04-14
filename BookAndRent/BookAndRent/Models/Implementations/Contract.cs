using BookAndRent.Models.Intefaces;
using System;

namespace BookAndRent.Models.Implementations
{
    public class Contract : IContract
    {
        public int Id { get; set; }
        public IUser Renter { get; set; }
        public IUser Holder { get; set; }
        public IApartment Apartment { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        
    }
}
