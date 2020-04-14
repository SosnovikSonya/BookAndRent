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
            Users = new TableList<IUser>(dbContext.Users.Select(dbUser => Mapper.Map<IUser>(dbUser)).ToList(), typeof(User));
            Users.ElementAdded += HandleItemAdded;
            Users.ElementUpdated += HandeItemUpdated;
        }

        public void Refresh()
        {
            // TODO: remove and add in generic way
            Users = new TableList<IUser>(DbContext.Users.Select(dbUser => Mapper.Map<IUser>(dbUser)).ToList(), typeof(User));

        }

        public ITableList<IUser> Users { get; set; }

        public void Save()
        {
            DbContext.SaveChanges();
            Refresh();
        }

        private void HandleItemAdded<T>(T item, Type dbType) where T: IUpdatable
        {
            DbContext.Add(Mapper.Map(item, typeof(T), dbType));
        }

        private void HandeItemUpdated<T>(T item, Type dbType) where T : IUpdatable
        {
            var obj = DbContext.Find(dbType, item.Id);
            DbContext.Remove(obj);
            DbContext.Add(Mapper.Map<User>(item));
        }
    }
}
