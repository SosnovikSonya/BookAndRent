using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Views.ViewModels.ApartmentModels
{
    public class ApartmentFacilities
    {
        public int ApartmentId { get; set; }
        public IEnumerable<Facility> Facilities { get; set; }
    }
}
