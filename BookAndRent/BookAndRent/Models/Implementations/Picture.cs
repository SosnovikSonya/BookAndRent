using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Implementations
{
    public class Picture : IPicture
    {
        public int PictureId { get; set; }
        public byte[] PictureBytes { get; set; }
    }
}
