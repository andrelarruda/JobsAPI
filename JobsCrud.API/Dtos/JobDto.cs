using JobsCrud.API.Models;
using System.Text.Json.Serialization;

namespace JobsCrud.API.Dtos
{
    public class JobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }

        [JsonConstructor]
        public JobDto() { }

        public JobDto(Job job)
        {
            Title = job.Title;
            Description = job.Description;
            Location = job.Location;
            Salary = job.Salary;
        }
    }
}
