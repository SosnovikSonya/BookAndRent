using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Models.Intefaces
{
    public interface IComment
    {
        int CommentId { get; set; }
        int ApartmentId { get; set; }
        int UserId { get; set; }
        string Content { get; set; }
        DateTime Date { get; set; }
    }
}
