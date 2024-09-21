using JobsCrud.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsCrud.API.Data
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "JobsDb");
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
