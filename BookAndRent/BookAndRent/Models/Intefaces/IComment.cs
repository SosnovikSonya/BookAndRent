using System;

namespace BookAndRent.Models.Intefaces
{
    public interface IComment : IIdenitifiable
    {
        IApartment Apartment { get; set; }
        IUser Commentator { get; set; }
        string Content { get; set; }
        DateTime Date { get; set; }
    }
}
