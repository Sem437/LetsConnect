using System.ComponentModel.DataAnnotations;

namespace LetsConnect.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

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

        [Required]
        public int StundentWorkshop1 { get; set; }

        [Required]
        public int StundentWorkshop2 { get; set; }

        [Required]
        public int StundentWorkshop3 { get; set; }

        [Required]
        public bool HasMidDay { get; set; } = false; //check om te kijken of student een workshop heeft in de middag
    }
}
