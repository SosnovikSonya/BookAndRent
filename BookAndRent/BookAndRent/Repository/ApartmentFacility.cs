using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository
{
    public class ApartmentFacility
    {
        public int ApartmentFacilityId { get; set; }
        public int ApartmentId { get; set; }
        public int FacilityId { get; set; }
    }
}
