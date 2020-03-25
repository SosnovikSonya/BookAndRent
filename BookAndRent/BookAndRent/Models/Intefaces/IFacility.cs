using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Intefaces
{
    public interface IFacility
    {
        int FacilityId { get; set; }
        string Title { get; set; }
    }
}
