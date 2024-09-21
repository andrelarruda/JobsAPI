using JobsCrud.API.Dtos;
using System.ComponentModel.DataAnnotations;

namespace JobsCrud.API.Models
{
    public class Job
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }

        public Job(string title, string description, string location, decimal salary)
        {
            Title = title;
            Description = description;
            Location = location;
            Salary = salary;
        }

        public Job() { }
    }
}
