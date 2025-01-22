using System.ComponentModel.DataAnnotations;

namespace LetsConnect.Models
{
    public class TemporaryWorkshopRegistration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string? Insert { get; set; }

        [Required]
        public string LastName{ get; set; }

        [Required]
        public string StudentClass { get; set; }

        [Required]
        public int WorkshopId { get; set; }

        [Required]
        public int WorkshopTimeId { get; set; }

        public string ConformationToken { get; set; }
    }
}
