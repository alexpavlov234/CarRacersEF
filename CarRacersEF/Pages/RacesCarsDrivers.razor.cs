using Blazored.Modal.Services;
using CarRacersEF.Data;
using CarRacersEF.Models;
using Microsoft.AspNetCore.Components;

namespace CarRacersEF.Pages
{
    public partial class RacesCarsDrivers
    {
       
        int raceAdd;
        int carAdd;
        int driverAdd;
        int Mileage;
        int Length;
        int Points;
       
        List<RaceDriverCar> carAndDriverRaces;
        List<Driver> drivers;
        List<Car> cars;
        List<Race> races;





        [Inject]
        CarContext context { get; set; } = default;
       
        private async Task AddRacesCarsDrivers()
        {
            RaceDriverCar raceDriverCar = new RaceDriverCar();
            raceDriverCar.Car = cars.Find(x => x.IdCar == carAdd);
            raceDriverCar.Race = races.Find(x => x.IdRace == raceAdd);
            raceDriverCar.Driver = drivers.Find(x => x.IdDriver == driverAdd);
      
            if (raceDriverCar.Car == null || raceDriverCar.Driver == null || raceDriverCar.Race == null || Mileage < 0 || Length < 0 || Points < 0)
            {
                modal.Show<ErrorPopUp>("Грешка");
            }
            else
            {      raceDriverCar.Car.IdCar = carAdd;
            raceDriverCar.Race.IdRace = raceAdd;
            raceDriverCar.Driver.IdDriver = driverAdd;
            raceDriverCar.Mileage = Mileage;
            raceDriverCar.Length = Length;
            raceDriverCar.Points = Points;
            raceDriverCar.Car.MileageCar += Mileage;
            raceDriverCar.Driver.PointsDriver += Points;
                context.Cars.Update(raceDriverCar.Car);
                context.Drivers.Update(raceDriverCar.Driver);
                context.RacesDriversCars.Add(raceDriverCar);
                context.SaveChanges();    
                carAdd = 0;
            raceAdd = 0;
            driverAdd = 0;

            }
        
            await OnInitializedAsync();
        }
        private async Task RemoveRacesCarsDrivers(RaceDriverCar race)
        {
            race.Car = cars.Find(x => x.IdCar == race.Car.IdCar);
            race.Race = races.Find(x => x.IdRace == race.Race.IdRace);
            race.Driver = drivers.Find(x => x.IdDriver == race.Driver.IdDriver);
            race.Car.MileageCar -= race.Mileage;
            race.Driver.PointsDriver -= race.Points;
            context.Cars.Update(race.Car);
            context.Drivers.Update(race.Driver);
            context.RacesDriversCars.Remove(race);
            
            context.SaveChanges();
            await OnInitializedAsync();
        }
        public Car GetCar(int IdCar)
        {
            return cars.Find(x => x.IdCar == IdCar);
        }
        public Driver GetDriver(int IdDriver)
        {
            return drivers.Find(x => x.IdDriver == IdDriver);
        }
        public Race GetRace(int IdRace)
        {
            return races.Find(x => x.IdRace == IdRace);
        }
        
        protected override async Task OnInitializedAsync()
        {
            
            var query1 = context.RacesDriversCars.ToList();
            var query2 = context.Races.ToList();
            var query3 = context.Drivers.ToList();
            var query4 = context.Cars.ToList();
            carAndDriverRaces = query1;
            races = query2;
            drivers = query3;
            cars = query4;
         
            
        }
    }

}
