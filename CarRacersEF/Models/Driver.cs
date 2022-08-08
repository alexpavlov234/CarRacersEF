using System.ComponentModel.DataAnnotations;

namespace CarRacersEF.Models
{
    //Модел на таблица, която представлява състезател и неговите данни.
    public class Driver
    {

        [Key]
        public int IdDriver { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "Прекалено дълъг низ!")]
        public string FirstNameDriver { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "Прекалено дълъг низ!")]
        public string SecondNameDriver { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "Прекалено дълъг низ!")]
        public string LastNameDriver { get; set; }
        [Required]
        [Range(18, 120, ErrorMessage = "Невалидна възраст!")]
        public int AgeDriver { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "Прекалено дълъг низ!")]
        public string NationalityDriver { get; set; }
        [Required]
        public int PointsDriver { get; set; }

    }
}
