using BookAndRent.Models.Intefaces;

namespace BookAndRent.Models.Implementations
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public IUpdatable Save()
        //{
        //    if (Id != 0)
        //    {
        //        var index = Repository.Users.ToList().FindIndex(0, user => user.Id == Id);
        //        Repository.Users.Replace(index, this);
        //    }
        //    else
        //    {
        //        Repository.Users.Add(this);
        //    }
        //    Repository.Save();
            //var dbUser = _mapper.Map<Repository.User>(this);
            //if (Id != 0)
            //{
            //    var index = _context.Users.ToList().FindIndex(0, user => user.UserId == Id);
            //    var actualDbUser = _context.Users.ToList()[index];
            //    _context.Users.Remove(actualDbUser);                
            //}

            //_context.Users.Add(dbUser);
            //_context.SaveChanges();

        //    return null;//_mapper.Map<IUser>(dbUser); ;
        //}       
         
    }
}
