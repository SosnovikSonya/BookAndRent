using System;

namespace BookAndRent.Views.ViewModels.ApartmentModels
{
    public class Comment
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int CommentatorId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
