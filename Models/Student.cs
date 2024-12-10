using System.ComponentModel.DataAnnotations;

namespace LetsConnect.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }

        public string? UserId { get; set; }

        [Required]
        public int StudentNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string? inserts { get; set; } //Tussenvoegsel

        [Required]
        public string  Lastname { get; set; }

        [Required]
        public string StudentClass { get; set; }
    }
}
