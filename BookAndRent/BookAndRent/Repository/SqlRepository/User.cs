using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndRent.Repository.SqlRepository
{
    public class User : ITable
    {
        [Column("UserId")]
        [Key()]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Apartment> Apartments { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; }
    }
}
