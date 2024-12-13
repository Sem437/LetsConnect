using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LetsConnect.Models
{
    public class StudentModel : IdentityUser 
    {            
        public StudentModel() { } // Parameterloze constructor

        [Required]
        public int StudentNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string? Inserts { get; set; } //Tussenvoegsel

        [Required]
        public string  Lastname { get; set; }

        [Required]
        public string StudentClass { get; set; }
    }
}
