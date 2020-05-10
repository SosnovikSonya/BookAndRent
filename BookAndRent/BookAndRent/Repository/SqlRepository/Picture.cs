
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookAndRent.Repository.SqlRepository
{
    public class Picture : ITable
    {
        [Column("PictureId")]
        [Key()]
        public int Id { get; set; }
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
        public byte[] PictureBytes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
