using System;

namespace BookAndRent.Models.Intefaces
{
    public interface IContract: IIdenitifiable
    {
        IUser Renter { get; set; }
        IUser Holder { get; set; }
        IApartment Apartment { get; set; }
        DateTime ContractDate { get; set; }
        DateTime CheckIn { get; set; }
        DateTime CheckOut { get; set; }
    }
}
