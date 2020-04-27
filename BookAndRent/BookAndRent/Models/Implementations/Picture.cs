using BookAndRent.Models.Intefaces;

namespace BookAndRent.Models.Implementations
{
    public class Picture : IPicture
    {
        public int Id { get; set; }
        public byte[] PictureBytes { get; set; }
        public int ApartmentId { get; set; }
    }
}
