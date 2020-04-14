using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository.SqlRepository
{
    public class Picture
    {
        public int PictureId { get; set; }
        public int ApartmentId { get; set; }
        public byte[] PictureBytes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
