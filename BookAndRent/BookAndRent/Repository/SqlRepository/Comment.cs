using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndRent.Repository.SqlRepository
{
    public class Comment : ITable
    {
        [Column("CommentId")]
        [Key()]
        public int Id { get; set; }
        public Apartment Apartment { get; set; }
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
