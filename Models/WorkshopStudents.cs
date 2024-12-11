using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsConnect.Models
{
    public class WorkshopStudents
    {
        [Key]
        public int IdStudentWorkshop { get; set; }

        [Required]
        [ForeignKey("Id")]
        public string StudentId { get; set; } // StudentId = Id niet StudentNumber                

        [Required]
        [ForeignKey("WorkshopId")]
        public int WorkshopId { get; set; }
    }
}
