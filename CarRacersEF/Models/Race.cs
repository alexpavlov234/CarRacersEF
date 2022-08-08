using System.ComponentModel.DataAnnotations;

namespace CarRacersEF.Models
{
    //Модел на таблица, която представлява състезния.
    public class Race
    {
        [Key]
        public int IdRace { get; set; }
        [Required]
        public string TrackRace { get; set; }
        [Required]
        public DateTime DateRace { get; set; }
    }
}
