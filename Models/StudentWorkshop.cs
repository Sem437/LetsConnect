using System.ComponentModel.DataAnnotations;

namespace LetsConnect.Models
{
    public class StudentWorkshop
    {
        [Key]
        public int IdStudentWorkshop { get; set; }

        [Required]
        public int IdStudent { get; set; }
        public Student Student { get; set; }

        [Required]
        public int WorkshopId { get; set; }
        public WorkshopModel Workshop { get; set; }

        [Required]
        public string WorkshopType { get; set; } // Ochtend/middag
    }
}
