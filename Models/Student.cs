using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LetsConnect.Models
{
    public class Student : IdentityUser 
    {            
        public Student() { } // Parameterloze constructor

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
