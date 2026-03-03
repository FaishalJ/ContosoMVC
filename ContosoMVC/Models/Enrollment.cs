using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ContosoMVC.Models
{
    [Table("Enrollment")]
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }

    public enum Grade
    {
        A, B, C, D, F
    }
}
