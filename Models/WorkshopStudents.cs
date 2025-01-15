using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsConnect.Models
{
    public class WorkshopStudents
    {
        [Key]
        public int IdStudentWorkshop { get; set; }

        [Required]        
        public string Email { get; set; }              

        [Required]
        [ForeignKey("WorkshopId")]
        public int WorkshopId { get; set; }
    }
}
