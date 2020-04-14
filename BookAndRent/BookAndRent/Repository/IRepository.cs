using BookAndRent.Models.Intefaces;

namespace BookAndRent.Repository
{
    public interface IRepository
    {
        ITableList<IUser> Users { get; set; }
        void Save();
        void Refresh();
    }
}
