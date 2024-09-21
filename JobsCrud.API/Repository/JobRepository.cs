using JobsCrud.API.Data;
using JobsCrud.API.Dtos;
using JobsCrud.API.Models;

namespace JobsCrud.API.Repository
{
    public class JobRepository : IJobRepository
    {

        public JobRepository() {
            using (var context = new ApiContext())
            {
                var jobs = new List<Job> {
                    new Job
                    {
                        Title = ".NET Full Stack Developer",
                        Description = "Create complex and simple applications to attend client needs.",
                        Location = "Los Angeles - CA",
                        Salary = 4700
                    },
                    new Job
                    {
                        Title = "React Front End Developer",
                        Description = "Create beautiful UIs thinking in usability.",
                        Location = "Pasadena - CA",
                        Salary = 2500
                    },
                    new Job
                    {
                        Title = "Gardener",
                        Description = "Keep the garden cleaned and beautiful.",
                        Location = "San Diego - CA",
                        Salary = 1800
                    },
                    new Job
                    {
                        Title = "Telemarketer",
                        Description = "Call to users and sell awesome and useful products.",
                        Location = "Orlando - FL",
                        Salary = 2000
                    }
                };
                context.AddRange(jobs);
                context.SaveChanges();
            }    
        }
        public Job CreateJob(JobDto jobDto)
        {
            using var context = new ApiContext();
            Job savedEntity = context.Add(new Job(jobDto.Title, jobDto.Description, jobDto.Location, jobDto.Salary)).Entity;
            context.SaveChanges();
            return savedEntity;
        }

        public void DeleteJobById(int id)
        {
            using var context = new ApiContext();
            if (!context.Jobs.Any(x => x.Id == id))
            {
                throw new KeyNotFoundException($"Job not found with id {id}.");
            }

            var job = context.Jobs.First(x => x.Id == id);
            context.Remove(job);
            context.SaveChanges();
        }

        public List<Job> GetAllJobs()
        {
            using var context = new ApiContext();
            return context.Jobs.ToList();
        }

        public Job GetJobById(int id)
        {
            using var context = new ApiContext();
            if (!context.Jobs.Any(j => j.Id == id)) throw new KeyNotFoundException($"Job not found.");

            return context.Jobs.Find(id);
        }

        public Job UpdateJob(int id, Job job)
        {
            using var context = new ApiContext();
            if (!context.Jobs.Any(j => j.Id == id)) throw new KeyNotFoundException($"Job not found.");

            var toUpdate = context.Jobs.Find(id);
            toUpdate.Title = job.Title;
            toUpdate.Description = job.Description;
            toUpdate.Location = job.Location;
            toUpdate.Salary = job.Salary;
            var updated = context.Jobs.Update(toUpdate);
            context.SaveChanges();
            return updated.Entity;
        }
    }
}
