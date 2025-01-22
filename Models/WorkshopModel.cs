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
        public int WorkshopMax { get; set; } //max personen in een workshop

        [Required]        
        public int WorkshopSignUps { get; set; } = 0; //hoeveel personen zich aanmelden voor een workshop        

        [Required]
        public string WorkshopType { get; set; } //Lokaal of Theater 

        public string? WorkshopIMG { get; set; }
    }
}
