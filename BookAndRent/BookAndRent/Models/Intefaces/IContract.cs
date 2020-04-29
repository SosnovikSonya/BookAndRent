using System;

namespace BookAndRent.Models.Intefaces
{
    public interface IContract: IIdenitifiable
    {
        int RenterId { get; set; }
        int HolderId { get; set; }
        int ApartmentId { get; set; }
        DateTime ContractDate { get; set; }
        DateTime CheckIn { get; set; }
        DateTime CheckOut { get; set; }
        decimal Amount { get; set; }
    }
}
