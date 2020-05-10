

namespace BookAndRent.Repository.SqlRepository
{
    public interface ITable
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
