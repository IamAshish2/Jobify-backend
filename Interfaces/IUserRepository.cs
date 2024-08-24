using jobify_Backend.Models;

namespace jobify_Backend.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        //ICollection<Job> GetAppliedJobs(int userId);
        User GetUser(int userId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool UserExists(int userId);
        bool Save();
    }
}
