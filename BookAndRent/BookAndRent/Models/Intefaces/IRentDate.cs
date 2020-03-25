using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Intefaces
{
    public interface IRentDate
    {
        int RentDateId { get; set; }
        int ApartmentId { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool IsOccupied { get; set; } 
    }
}
