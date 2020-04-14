using System;
using System.Collections.Generic;

namespace BookAndRent.Models.Intefaces
{
    public interface IApartment : IIdenitifiable
    {
        string Address { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Coordinates { get; set; }
        decimal CostPerNight { get; set; }
        int SleepingPlaces { get; set; }
        int RoomAmount { get; set; }
        List<IComment> Comments { get; set; }
        List<IFacility> Facilities { get; set; }
        List<IPicture> Pictures { get; set; }
        List<IAvailableDate> AvailableDates { get; set; }
        List<IContract> Contracts { get; set; }
        IUser HouseHolder { get; set; }

        bool IsDateAvailable(DateTime start, DateTime end);
        
        /// <summary>
        /// Rent means receive something from somebody
        /// </summary>
        /// <returns></returns>
        IContract Rent(IUser renter, DateTime start, DateTime end);
    }
}
