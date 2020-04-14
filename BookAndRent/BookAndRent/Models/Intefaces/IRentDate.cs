using System;

namespace BookAndRent.Models.Intefaces
{
    public interface IRentDate : IIdenitifiable
    {
        int ApartmentId { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
