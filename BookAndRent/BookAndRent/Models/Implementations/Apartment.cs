using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAndRent.Models.Implementations
{
    public class Apartment : IApartment
    {
        public int Id { get; set; }
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
        public List<IAvailableDate> AvailableDates { get; set; }
        public List<IContract> Contracts { get; set; }
        public IUser HouseHolder { get; set; }

        public Apartment()
        {
            Comments = new List<IComment>();
            Facilities = new List<IFacility>();
            Pictures = new List<IPicture>();
            AvailableDates = new List<IAvailableDate>();
            Contracts = new List<IContract>();
        }

        public bool IsDateAvailable(DateTime start, DateTime end)
        {           
            if (!AvailableDates.Any(date => date.StartDate <= start && date.EndDate >= end))
            {
                return false;
            }

            foreach (var contract in Contracts)
            {
                if (start > contract.CheckIn && start < contract.CheckOut)
                {
                    return false;
                }

                if (end > contract.CheckIn && end < contract.CheckOut)
                {
                    return false;
                }
            }

            return true;
        }

        public IContract Rent(IUser renter, DateTime start, DateTime end)
        {
            var contract = new Contract
            {
                Renter = renter,
                CheckIn = start,
                CheckOut = end,
                Holder = HouseHolder,
                ContractDate = DateTime.UtcNow,
                Apartment = this
            };

            Contracts.Add(contract);

            return contract;
        }        
    }
}
