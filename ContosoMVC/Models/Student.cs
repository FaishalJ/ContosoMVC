using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoMVC.Models
{
    [Table("Student")]
    public class Student
    {
        public int ID { get; set; }
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }
        [Display(Name = "First Mid Name")]
        public required string FirstMidName { get; set; }
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = [];
    }
}
