using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoMVC.Models
{

    [Table("Course")]
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public required string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public Department Department { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = [];
        public ICollection<CourseAssignment> CourseAssignments { get; set; } = [];
    }
}
