using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndRent.Repository.SqlRepository
{
    public class Contract : ITable
    {
        [Column("ContractId")]
        [Key()]
        public int Id { get; set; }
        [ForeignKey("Renter")]
        public int? RenterId { get; set; }
        public virtual User Renter { get; set; }
        [ForeignKey("Holder")]
        public int? HolderId { get; set; }
        public virtual User Holder { get; set; }
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
