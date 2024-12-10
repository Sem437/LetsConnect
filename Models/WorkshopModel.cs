using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace LetsConnect.Models
{
    public class WorkshopModel
    {
        [Key]
        public int WorkshopId { get; set; }

        [Required]
        public string WorkshopName { get; set; }

        [Required]
        public string WorkshopDescription { get; set; }

        [Required]
        public string WorkshopPlace { get; set; }

        [Required]
        public int WorkshopMax { get; set; } //max personen in een workshop

        //hoeveel personen zich aanmelden voor een workshop
        public int? WorkshopSignUps { get; set; } = 0;

        [Required]
        public DateOnly WorkshopDate { get; set; }

        [Required]
        public TimeOnly WorkshopStartTime { get; set; }

        [Required]
        public TimeOnly WorkshopEndTime { get; set; }

        [Required]
        public string WorkshopTeacher { get; set; }

        [Required]
        public int WorkshopRonde { get; set; }

        [Required]
        public string WorkshopType { get; set; } //Lokaal of Theater 

        public string? WorkshopIMG { get; set; }
    }
}
