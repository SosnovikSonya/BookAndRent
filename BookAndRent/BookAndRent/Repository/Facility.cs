using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository
{
    public class Facility
    {
        public int FacilityId { get; set; }
        public string Title { get; set; }
        public List<ApartmentFacility> ApartmentFacilities { get; set; }
        public bool IsDeleted { get; set; }
    }
}
