using System.ComponentModel.DataAnnotations;

namespace ContosoMVC.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        [StringLength(50)]
        [Display(Name = "Office Location")]
        public required string Location { get; set; }

        public Instructor Instructor { get; set; } = null!;
    }
}
