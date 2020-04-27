

namespace BookAndRent.Models.Intefaces
{
    public interface IPicture : IIdenitifiable
    {
        int ApartmentId { get; set; }
        byte[] PictureBytes { get; set; }
    }
}
