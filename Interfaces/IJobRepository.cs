using jobify_Backend.Models;

namespace jobify_Backend.Interfaces
{
    public interface IJobRepository
    {
        ICollection<Job> GetJobs();
        Job GetJob(int id);
        bool DeleteJob(Job job);
        bool CreateJob(Job job);
        bool UpdateJob(Job job);
        bool JobExists(int JobId);
        bool Save();

    }
}
