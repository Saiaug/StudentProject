using Microsoft.EntityFrameworkCore;

namespace StudentProject.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options) { }
        DbSet<Student> Students { get; set; }
       
    }
}
