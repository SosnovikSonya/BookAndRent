using BookAndRent.Models.Intefaces;
using System;

namespace BookAndRent.Models.Implementations
{
    public class Comment : IComment
    {
        public int Id { get; set; }
        public IApartment Apartment { get; set; }
        public IUser Commentator { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

    }
}
