using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class StudentWebApiContext : DbContext
    {
        public StudentWebApiContext(DbContextOptions<StudentWebApiContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 4,
                    FullName = "LukasBrands",
                     Email="lukas@gamil.com",
                      Age=21,
                       Mobile=051178965,
                        Address="kassel, Germany"

                }
                );
        }
    }
}
