using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;


namespace Login_Form
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
    public class Student
    {
        [Key] // ✅ Primary Key
        public int Id { get; set; }

        [Required] // ✅ Makes UserName mandatory
        public string UserName { get; set; }

        [Required] // ✅ Makes Password mandatory
        public string Password { get; set; }
    }
}
