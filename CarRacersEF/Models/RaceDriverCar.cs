

using System.ComponentModel.DataAnnotations;

namespace CarRacersEF.Models
{
    //Модел на таблица, която съхранява информация в кое състезание даден състезател е участвал и информация за точките, пробега и времетраенето на участието. 
    public class RaceDriverCar
    {
        [Key]
        public int Id { get; set; }

        public int IdCar { get; set; }
        public Car Car { get; set; }

        public int IdDriver { get; set; }
        public Driver Driver { get; set; }

        public int IdRace { get; set; }
        public Race Race { get; set; }

        [Required]
        public int Mileage { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Points { get; set; }





    }
}
