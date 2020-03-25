using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Intefaces
{
    public interface IContract
    {
        int ContractId { get; set; }
        int UserId { get; set; }
        int ApartmentId { get; set; }
        DateTime ContractDate { get; set; }
        DateTime CheckIn { get; set; }
        DateTime CheckOut { get; set; }
    }
}
