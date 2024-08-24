using jobify_Backend.Data;
using jobify_Backend.Interfaces;
using jobify_Backend.Models;

namespace jobify_Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        // check this method properly
        //public ICollection<Job> GetAppliedJobs(int userId)
        //{
        //    return _context.Jobs.Where(j => j.UserId == userId).ToList();
        //}

        public User GetUser(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.UserId).ToList();  
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).Any();
        }
    }
}
