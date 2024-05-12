using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class StudentWebApiContext:DbContext
    {
        public StudentWebApiContext(DbContextOptions<StudentWebApiContext> options)
            : base(options)
        {
                
        }

        public DbSet<Student> Students { get; set; }
    }
}
