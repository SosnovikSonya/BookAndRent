using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Intefaces
{
    public interface IPicture
    {
        int PictureId { get; set; }
        byte[] PictureBytes { get; set; }
    }
}
