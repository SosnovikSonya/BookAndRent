using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Implementations
{
    public class Facility : IFacility
    {
        public int FacilityId { get; set; }
        public string Title { get; set; }
    }
}
