using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Views.ViewModels.ApartmentModels
{
    public class ApartmentPicture
    {
        public int ApartmentId { get; set; }
        public byte[] PictureBytes { get; set; }
    }
}
