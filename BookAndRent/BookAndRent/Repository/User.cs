using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Apartment> Apartments { get; set; }
        public List<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; }
    }
}
