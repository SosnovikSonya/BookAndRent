using BookAndRent.Views.ViewModels.ApartmentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Views.ViewModels.UserModels
{
    public class Contract
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }         
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal Amount { get; set; }        
        public int RenterId { get; set; }
        public int HolderId { get; set; }
        public UserRegistration Renter { get; set; }
        public AvailableApartmentInfo Apartment { get; set; }
        public ContractStatus ContractStatus { get; set; }
    }
}
