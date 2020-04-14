using BookAndRent.Models.Intefaces;

namespace BookAndRent.Models.Implementations
{
    public class Facility : IFacility
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
    }
}
