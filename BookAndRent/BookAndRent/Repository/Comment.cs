using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int? ApartmentId { get; set; }
        public int? UserId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
