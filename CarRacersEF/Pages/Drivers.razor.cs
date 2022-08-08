using Blazored.Modal.Services;
using CarRacersEF.Data;
using CarRacersEF.Models;
using Microsoft.AspNetCore.Components;

namespace CarRacersEF.Pages
{
    public partial class Drivers
    {
 
        List<Driver> drivers;
        [Inject]
        CarContext context { get; set; } = default;
        private string FirstName { get; set; }
        private string SecondName { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; } = 18;
        private string Nationality { get; set; }
        private int Points { get; set; }

        private async Task AddDriver()
        {
            Driver driver = new Driver();

            driver.FirstNameDriver = FirstName;
            driver.SecondNameDriver = SecondName;
            driver.LastNameDriver = LastName;
            driver.AgeDriver = Age;
            driver.NationalityDriver = Nationality;
            driver.PointsDriver = Points;
            if (driver.FirstNameDriver == null || driver.SecondNameDriver == null || driver.LastNameDriver == null || driver.AgeDriver < 18 || driver.NationalityDriver == null || driver.PointsDriver < 0)
            {
                modal.Show<ErrorPopUp>("Грешка");
            }
            else
            {
                context.Drivers.Add(driver);
                context.SaveChanges();
                FirstName = null;
               SecondName = null;
               LastName = null;
                Nationality = null;
                Points =0;
               Age = 0;
       
            }
            await OnInitializedAsync();
        }
        private async Task RemoveDriver(Driver driver)
        {

            context.Drivers.Remove(driver);
            context.SaveChanges();
            await OnInitializedAsync();
        }
        private async Task UpdateDriver(Driver driver)
        {
            if (driver.FirstNameDriver == null || driver.SecondNameDriver == null || driver.LastNameDriver == null || driver.AgeDriver < 18 || driver.NationalityDriver == null || driver.PointsDriver < 0)
            {
                modal.Show<ErrorPopUp>("Грешка");
            }
            else
            {
                context.Drivers.Update(driver);
                context.SaveChanges();
            }
            await OnInitializedAsync();
        }
        protected override async Task OnInitializedAsync()
        {
            var query = context.Drivers.ToList();
            drivers = query;
        }
    }
}
