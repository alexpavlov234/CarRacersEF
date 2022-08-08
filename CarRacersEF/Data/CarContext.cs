using CarRacersEF.Models;

using Microsoft.EntityFrameworkCore;
namespace CarRacersEF.Data
{
    //Нашия контекстен клас CarContext, който наследява DbContext, който е вход към нашата база данни.
    public class CarContext : DbContext
    {
        //Конструктор, който приема параметър от тип DbContextOptions, който носи конфигурационна информация. Констукторът подвава параметъра на конструктора на CarContext на DbContext.
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }
        //DbSet-ове, kойто представляват таблиците в нашата база данни.
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceDriverCar> RacesDriversCars { get; set; }
        //Извиква се, когато се инициализира класът.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(new Car { IdCar = 1, ModelCar = "956", BrandCar = "Porsche", MileageCar = 234, ServiceDateCar = new DateTime(2022, 01, 09) },
             new Car { IdCar = 2, ModelCar = "R8", BrandCar = "Audi", MileageCar = 234, ServiceDateCar = new DateTime(2022, 01, 09) },
             new Car { IdCar = 3, ModelCar = "GT-R R32", BrandCar = "Skyline", MileageCar = 234, ServiceDateCar = new DateTime(2022, 01, 09) },
             new Car { IdCar = 4, ModelCar = "PC-23", BrandCar = "Penske", MileageCar = 234, ServiceDateCar = new DateTime(2022, 01, 09) },
             new Car { IdCar = 5, ModelCar = "M8", BrandCar = "McLaren", MileageCar = 234, ServiceDateCar = new DateTime(2022, 01, 09) }
                                                                                                                               );
            modelBuilder.Entity<Driver>().HasData(new Driver { IdDriver = 1, FirstNameDriver = "Александър", SecondNameDriver = "Теодоров", LastNameDriver = "Иванов", AgeDriver = 19, NationalityDriver = "България", PointsDriver = 12 },
             new Driver { IdDriver = 2, FirstNameDriver = "Петър", SecondNameDriver = "Николов", LastNameDriver = "Ангелов", AgeDriver = 20, NationalityDriver = "България", PointsDriver = 43 },
             new Driver { IdDriver = 3, FirstNameDriver = "Hans", SecondNameDriver = "Florian", LastNameDriver = "Moritz", AgeDriver = 29, NationalityDriver = "Германия", PointsDriver = 98 },
             new Driver { IdDriver = 4, FirstNameDriver = "Виолета", SecondNameDriver = "Теодорова", LastNameDriver = "Денева", AgeDriver = 25, NationalityDriver = "България", PointsDriver = 2 },
             new Driver { IdDriver = 5, FirstNameDriver = "Николай", SecondNameDriver = "Петров", LastNameDriver = "Драгиев", AgeDriver = 19, NationalityDriver = "България", PointsDriver = 0 });
            modelBuilder.Entity<Race>().HasData(new Race { IdRace = 1, TrackRace = "Monte Carlo", DateRace = new DateTime(2022, 08, 09) },
             new Race { IdRace = 2, TrackRace = "Autodromo Nazionale di Monza", DateRace = new DateTime(2021, 09, 30) },
             new Race { IdRace = 3, TrackRace = "Circuit de Spa-Francorchamps", DateRace = new DateTime(2021, 08, 17) },
             new Race { IdRace = 4, TrackRace = "Nurburgring Nordschleife", DateRace = new DateTime(2022, 01, 15) },
             new Race { IdRace = 5, TrackRace = "Circuit de la Sarthe", DateRace = new DateTime(2021, 02, 26) });

        }


    }
}
