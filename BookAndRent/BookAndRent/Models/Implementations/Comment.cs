using BookAndRent.Models.Intefaces;
using System;

namespace BookAndRent.Models.Implementations
{
    public class Comment : IComment
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int CommentatorId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

    }
}
