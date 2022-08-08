using System.ComponentModel.DataAnnotations;

namespace CarRacersEF.Models
{
    //Модел на таблица, която представлява състезателна кола и нейнте параметри.
    public class Car
    {
        [Key]
        public int IdCar { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Прекалено дълъг низ!")]
        public string ModelCar { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Прекалено дълъг низ!")]
        public string BrandCar { get; set; }
        [Required]
        public int MileageCar { get; set; }
        [Required]
        public DateTime ServiceDateCar { get; set; }


    }
}
