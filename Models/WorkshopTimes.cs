using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsConnect.Models
{
    public class WorkshopTimes
    {
        [Key]
        public int WorkshopTimeId { get; set; }

        [Required]
        [ForeignKey("WorkshopId")]
        public int WorkshopId { get; set; }

        [Required]
        public int WorkshopRonde{ get; set; }

        [Required]
        public string WorkshopPlace { get; set; }

        [Required]
        public DateOnly WorkshopDate { get; set; }

        [Required]
        public TimeOnly WorkshopStartTime { get; set; }

        [Required]
        public TimeOnly WorkshopEndTime { get; set; }

        [Required]
        public string WorkshopTeacher { get; set; }
    }
}
