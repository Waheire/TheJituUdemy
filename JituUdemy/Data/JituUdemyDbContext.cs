using JituUdemy.Entities;
using Microsoft.EntityFrameworkCore;

namespace JituUdemy.Data
{
    public class JituUdemyDbContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public JituUdemyDbContext(DbContextOptions<JituUdemyDbContext> options) : base(options)
        {
            
        }
    }
}
