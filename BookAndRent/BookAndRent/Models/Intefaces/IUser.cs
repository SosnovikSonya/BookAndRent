

namespace BookAndRent.Models.Intefaces
{
    public interface IUser : IIdenitifiable
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
