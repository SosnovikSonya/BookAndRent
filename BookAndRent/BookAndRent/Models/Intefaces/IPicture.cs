

namespace BookAndRent.Models.Intefaces
{
    public interface IPicture : IIdenitifiable
    {
        byte[] PictureBytes { get; set; }
    }
}
