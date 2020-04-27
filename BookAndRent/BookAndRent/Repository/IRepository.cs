using BookAndRent.Models.Intefaces;
using BookAndRent.Repository.SqlRepository;
using System.Collections.Generic;

namespace BookAndRent.Repository
{
    public interface IRepository
    {
        ITableList<IUser> Users { get; set; }
        ITableList<IApartment> Apartments { get; set; }
        //ITableList<IFacility> Facilities { get; set; }
        ITableList<IComment> Comments { get; set; }
        ITableList<IContract> Contracts { get; set; }
        ITableList<IAvailableDate> AvailableDates { get; set; }
        ITableList<IPicture> Pictures { get; set; }

        void Save();
        void Refresh();      
    }
}
