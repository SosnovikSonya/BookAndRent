using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookAndRent.Models.Intefaces;
using Microsoft.EntityFrameworkCore;

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

            Refresh();
        }

        public void Refresh()
        {
            Users = new TableList<IUser, User>(CheckDeletedAndMap<IUser, User>(DbContext.Users));
            Apartments = new TableList<IApartment, Apartment>(CheckDeletedAndMap<IApartment, Apartment>(DbContext.Apartments));
            Comments = new TableList<IComment, Comment>(CheckDeletedAndMap<IComment, Comment>(DbContext.Comments));
            Pictures = new TableList<IPicture, Picture>(CheckDeletedAndMap<IPicture, Picture>(DbContext.Pictures));
            AvailableDates = new TableList<IAvailableDate, AvailableDate>(CheckDeletedAndMap<IAvailableDate, AvailableDate>(DbContext.AvailableDates));
            Contracts = new TableList<IContract, Contract>(CheckDeletedAndMap<IContract, Contract>(DbContext.Contracts));

            Users.ElementAdded += (IUser item) => HandleItemAddedOrUpdated(item, typeof(User));
            Users.ElementUpdated += (IUser item) => HandleItemAddedOrUpdated(item, typeof(User));
            Users.ElementDeleted += (IUser item) => HandeItemDeleted(item, typeof(User));

            Apartments.ElementAdded += (IApartment item) => HandleItemAddedOrUpdated(item, typeof(Apartment));
            Apartments.ElementUpdated += (IApartment item) => HandleItemAddedOrUpdated(item, typeof(Apartment));
            Apartments.ElementDeleted += (IApartment item) => HandeItemDeleted(item, typeof(Apartment));

            Comments.ElementAdded += (IComment item) => HandleItemAddedOrUpdated(item, typeof(Comment));
            Comments.ElementUpdated += (IComment item) => HandleItemAddedOrUpdated(item, typeof(Comment));
            Comments.ElementDeleted += (IComment item) => HandeItemDeleted(item, typeof(Comment));

            Pictures.ElementAdded += (IPicture item) => HandleItemAddedOrUpdated(item, typeof(Picture));
            Pictures.ElementUpdated += (IPicture item) => HandleItemAddedOrUpdated(item, typeof(Picture));
            Pictures.ElementDeleted += (IPicture item) => HandeItemDeleted(item, typeof(Picture));

            AvailableDates.ElementAdded += (IAvailableDate item) => HandleItemAddedOrUpdated(item, typeof(AvailableDate));
            AvailableDates.ElementUpdated += (IAvailableDate item) => HandleItemAddedOrUpdated(item, typeof(AvailableDate));
            AvailableDates.ElementDeleted += (IAvailableDate item) => HandeItemDeleted(item, typeof(AvailableDate));

            Contracts.ElementAdded += (IContract item) => HandleItemAddedOrUpdated(item, typeof(Contract));
            Contracts.ElementUpdated += (IContract item) => HandleItemAddedOrUpdated(item, typeof(Contract));
            Contracts.ElementDeleted += (IContract item) => HandeItemDeleted(item, typeof(Contract));
        }        

        public ITableList<IUser> Users { get; set; }
        public ITableList<IApartment> Apartments { get; set; }
        public ITableList<IComment> Comments { get; set; }
        public ITableList<IPicture> Pictures { get; set; }
        public ITableList<IAvailableDate> AvailableDates { get; set; }
        public ITableList<IContract> Contracts { get; set; }

        public void Save()
        {
            DbContext.SaveChanges();
            Refresh();
        }

        private void HandleItemAddedOrUpdated(IIdenitifiable item, Type dbType)
        {
            DbContext.AddOrUpdate(Mapper.Map(item, item.GetType(), dbType) as ITable);
        }

        private void HandeItemDeleted(IIdenitifiable item, Type dbType)
        {
            var obj = Mapper.Map(item, item.GetType(), dbType) as ITable;
            obj.IsDeleted = true;
            DbContext.AddOrUpdate(obj);
        }

        private List<TTarget> CheckDeletedAndMap<TTarget, TDb>(DbSet<TDb> collection) where TDb : class, ITable
        {
            return collection.Where(item => !item.IsDeleted).Select(dbUser => Mapper.Map<TTarget>(dbUser)).ToList();
        }
    }
}
