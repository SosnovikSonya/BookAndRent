using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Intefaces
{
    public interface IUser
    {
        int UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
