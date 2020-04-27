using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository.SqlRepository
{
    public class Comment : ITable
    {
        [Column("CommentId")]
        [Key()]
        public int Id { get; set; }
        public int? ApartmentId { get; set; }
        public int? UserId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
