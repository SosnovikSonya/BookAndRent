using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookAndRent.Models.Intefaces;

namespace BookAndRent.Repository.SqlRepository
{
    public class SqlServerRepository : IRepository
    {
        private IMapper Mapper { get; set; }
        private BookAndRentDBContext DbContext { get; set; }

        public SqlServerRepository(IMapper mapper, BookAndRentDBContext dbContext)
        {
            Mapper = mapper;
            DbContext = dbContext;
            // TODO: remove and add in generic way
            Users = new TableList<IUser, User>(dbContext.Users.Select(dbUser => Mapper.Map<IUser>(dbUser)).ToList());
            Users.ElementAdded += HandleUserAdded;
            Users.ElementUpdated += HandeUserUpdated;
            Users.ElementDeleted += HandeUserDeleted;


            Apartments = new TableList<IApartment, Apartment>(dbContext.Apartments.Select(dbApartment => Mapper.Map<IApartment>(dbApartment)).ToList());
            Apartments.ElementAdded += HandleApartmentAdded;
            Apartments.ElementUpdated += HandeApartmentUpdated;
            Apartments.ElementDeleted += HandeApartmentDeleted;


            // //Facilities = new TableList<IFacility>(dbContext.Facilities.Select(dbFacility => Mapper.Map<IFacility>(dbFacility)).ToList(), typeof(Facility));
            // //Facilities.ElementAdded += HandleItemAdded;
            // //Facilities.ElementUpdated += HandeItemUpdated;

            // Comments = new TableList<IComment>(DbContext.Comments.Select(dbComment => Mapper.Map<IComment>(dbComment)).ToList(), typeof(Comment));
            // Comments.ElementAdded += HandleItemAdded;
            // //Comments.ElementUpdated += HandeItemUpdated;

            // Pictures = new TableList<IPicture>(DbContext.Pictures.Select(dbPicture => Mapper.Map<IPicture>(dbPicture)).ToList(), typeof(Picture));
            // Pictures.ElementAdded += HandleItemAdded;
            //// Pictures.ElementUpdated += HandeItemUpdated;

            // AvailableDates = new TableList<IAvailableDate>(DbContext.AvailableDates.Select(dbAvailableDate => Mapper.Map<IAvailableDate>(dbAvailableDate)).ToList(), typeof(AvailableDate));
            // AvailableDates.ElementAdded += HandleItemAdded;
            //// AvailableDates.ElementUpdated += HandeItemUpdated;

            // Contracts = new TableList<IContract>(DbContext.Contracts.Select(dbContract => Mapper.Map<IContract>(dbContract)).ToList(), typeof(Contract));
            // Contracts.ElementAdded += HandleItemAdded;
            //// Contracts.ElementUpdated += HandeItemUpdated;

        }

        public void Refresh()
        {
            // TODO: remove and add in generic way
            Users = new TableList<IUser, User>(DbContext.Users.Select(dbUser => Mapper.Map<IUser>(dbUser)).ToList());
            Apartments = new TableList<IApartment, Apartment>(DbContext.Apartments.Select(dbApartment => Mapper.Map<IApartment>(dbApartment)).ToList());
            ////Facilities = new TableList<IFacility>(DbContext.Facilities.Select(dbFacility => Mapper.Map<IFacility>(dbFacility)).ToList(), typeof(Facility));
            //Comments = new TableList<IComment>(DbContext.Comments.Select(dbComment => Mapper.Map<IComment>(dbComment)).ToList(), typeof(Comment));
            //Pictures = new TableList<IPicture>(DbContext.Pictures.Select(dbPicture => Mapper.Map<IPicture>(dbPicture)).ToList(), typeof(Picture));
            //AvailableDates = new TableList<IAvailableDate>(DbContext.AvailableDates.Select(dbAvailableDate => Mapper.Map<IAvailableDate>(dbAvailableDate)).ToList(), typeof(AvailableDate));
            //Contracts = new TableList<IContract>(DbContext.Contracts.Select(dbContract => Mapper.Map<IContract>(dbContract)).ToList(), typeof(Contract));

        }
      


        public ITableList<IUser> Users { get; set; }
        public ITableList<IApartment> Apartments { get; set; }
        //public ITableList<IFacility> Facilities { get; set; }
        public ITableList<IComment> Comments { get; set; }
        public ITableList<IPicture> Pictures { get; set; }
        public ITableList<IAvailableDate> AvailableDates { get; set; }
        public ITableList<IContract> Contracts { get; set; }

        public void Save()
        {
            DbContext.SaveChanges();
            Refresh();
        }

        //private void HandleApartmentFacilities(IApartment apartment)
        //{
        //    var apartmentFacilities = DbContext.ApartmentFacilities.Where(apfac => apfac.ApartmentId == apartment.Id);
        //    DbContext.RemoveRange(apartmentFacilities);

        //    foreach (var facility in apartment.Facilities)
        //    {
        //        if (!DbContext.ApartmentFacilities.Where(apfac => apfac.ApartmentId == apartment.Id)
        //            .Any(apfac => apfac.FacilityId == facility.Id))
        //        {
        //            DbContext.Add(new ApartmentFacility
        //            {
        //                ApartmentId = apartment.Id,
        //                FacilityId = facility.Id
        //            });
        //        }
        //    }           
        //}

        private void HandleUserAdded(IUser item)
        {
            DbContext.Add(Mapper.Map<User>(item));
        }

        private void HandeUserUpdated(IUser item)
        {
            var obj = DbContext.Find(typeof(User), item.Id);
            //DbContext.Remove(obj);
            //DbContext.Add(Mapper.Map<User>(item));

            obj = item;
        }

        private void HandeUserDeleted(IUser item)
        {
            var obj = DbContext.Find(typeof(User), item.Id);
            DbContext.Remove(obj);
        }

        private void HandleApartmentAdded(IApartment item)
        {
            DbContext.Add(Mapper.Map<Apartment>(item));
        }

        private void HandeApartmentUpdated(IApartment item)
        {
            var obj = DbContext.Apartments.SingleOrDefault(ap => ap.Id == item.Id);
            //DbContext.Remove(obj);
            //DbContext.Add(Mapper.Map<Apartment>(item));

            //obj = Mapper.Map<Apartment>(item);
            obj = CopyProperties(Mapper.Map<Apartment>(item), obj);
        }

        private void HandeApartmentDeleted(IApartment item)
        {
            var obj = DbContext.Find(typeof(Apartment), item.Id);
            DbContext.Remove(obj);
        }

        private T CopyProperties<T>(T source, T target)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                prop.SetValue(target, prop.GetValue(source));
            }
            return target;
        }
    }
}
