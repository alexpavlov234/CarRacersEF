using Blazored.Modal.Services;
using CarRacersEF.Data;
using CarRacersEF.Models;
using Microsoft.AspNetCore.Components;

namespace CarRacersEF.Pages
{
    public partial class Cars
    {
  

        List<Car> cars;
        [Inject]
        CarContext context { get; set; } = default;
        private string Model { get; set; }
        private string Brand { get; set; }
        private int Mileage { get; set; }
        private DateTime ServiceDate { get; set; } = DateTime.Now;

        private async Task AddCar()
        {

            Car Car = new Car();
            Car.ModelCar = Model;
            Car.BrandCar = Brand;
            Car.MileageCar = Mileage;
            Car.ServiceDateCar = ServiceDate;
            if (Car.MileageCar < 0 || Car.BrandCar == null || Car.ModelCar == null || Car.ServiceDateCar > DateTime.Now)
            {
                modal.Show<ErrorPopUp>("Грешка");
            }
            else
            {
                context.Cars.Add(Car);
                context.SaveChanges();  
                Model = null;
                Brand = null;
                Mileage = 0;
            }
              
            
            await OnInitializedAsync();

        }
        private async Task RemoveCar(Car car)
        {

            context.Cars.Remove(car);
            context.SaveChanges();
            await OnInitializedAsync();

        }
        private async Task UpdateCar(Car car)
        {
            if(car.MileageCar < 0)
            {
                modal.Show<ErrorPopUp>("Грешка");
            }
            else
            {
                context.Cars.Update(car);
                context.SaveChanges();
            }
            
            await OnInitializedAsync();

        }
        protected override async Task OnInitializedAsync()
        {
            Model = null;
            Brand = null;
            Mileage = 0;
            var query = context.Cars.ToList();
            cars = query;

        }
    }
}
