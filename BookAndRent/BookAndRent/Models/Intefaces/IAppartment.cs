using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Intefaces
{
    public interface IApartment
    {
        int ApartmentId { get; set; }
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
        List<IRentDate> AvailableDates { get; set; }
        List<IContract> Contracts { get; set; }
        IUser HouseHolder { get; set; }
    }
}
