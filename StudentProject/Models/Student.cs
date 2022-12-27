using System.ComponentModel.DataAnnotations;

namespace StudentProject.Models
{
    public class Student
    {
        [Key]
        public string? Rollno { get; set; }
        
        public string? StudentFirstName { get; set; }
        
        public string? StudentLastName { get; set; }
        
        public string? Class { get; set; }
        //[Required]
        //public string? Section { get; set; }

        public int YearofEnrollment { get; set; }
        
    }
}
