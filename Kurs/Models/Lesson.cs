using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kurs.Models
{
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }

        [Required]
        [Display(Name = "Group")]
        public int GroupID { get; set; }

        [ForeignKey("GroupID")]
        public Group Group { get; set; }

        [Required]
        [Display(Name = "Instructor")]
        public int InstructorID { get; set; }

        [ForeignKey("InstructorID")]
        public Instructor Instructor { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date and Time")]
        public DateTime DateTime { get; set; }

        [StringLength(50)]
        [Display(Name = "Lesson Type")]
        public string LessonType { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
