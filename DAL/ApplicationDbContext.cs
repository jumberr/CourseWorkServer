using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  
        {  
  
        }  
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
        }

        public DbSet<Person> Persons { get; set; } 
        public DbSet<ToDo> ToDos { get; set; } 
        public DbSet<Bday> Bdays { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}