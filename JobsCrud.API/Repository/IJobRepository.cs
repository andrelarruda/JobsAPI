using JobsCrud.API.Dtos;
using JobsCrud.API.Models;

namespace JobsCrud.API.Repository
{
    public interface IJobRepository
    {

        public List<Job> GetAllJobs();

        public Job GetJobById(int id);

        public void DeleteJobById(int id);

        public Job CreateJob(JobDto job);

        public Job UpdateJob(int id, Job job);
    }
}
