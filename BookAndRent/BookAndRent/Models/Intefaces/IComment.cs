using System;

namespace BookAndRent.Models.Intefaces
{
    public interface IComment : IIdenitifiable
    {
        int ApartmentId { get; set; }
        int CommentatorId { get; set; }
        string Content { get; set; }
        DateTime Date { get; set; }
    }
}
