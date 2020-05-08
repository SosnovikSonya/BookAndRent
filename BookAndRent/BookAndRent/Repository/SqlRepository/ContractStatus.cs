using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository.SqlRepository
{
    public enum ContractStatus
    {
        New = 0,
        Approved = 1,
        InProgress = 2,
        Rejected = 3,
        Completed = 4
    }
}
