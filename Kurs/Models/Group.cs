using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kurs.Models
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }


        [Required]
        [Display(Name = "Student")]
        public int StudentID { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseID { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Max Students")]
        public int MaxStudents { get; set; }
    }
}
