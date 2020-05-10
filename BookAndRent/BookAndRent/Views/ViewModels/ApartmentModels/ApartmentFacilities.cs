using System.Collections.Generic;

namespace BookAndRent.Views.ViewModels.ApartmentModels
{
    public class ApartmentFacilities
    {
        public int ApartmentId { get; set; }
        public IEnumerable<Facility> Facilities { get; set; }
    }
}
