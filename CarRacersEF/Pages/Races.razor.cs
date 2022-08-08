using Blazored.Modal.Services;
using CarRacersEF.Data;
using CarRacersEF.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CarRacersEF.Pages
{
    public partial class Races
    {
      
        List<Race> races;
        [Inject]
        CarContext context { get; set; } = default;
       
        private string Track { get; set; }
        private DateTime Date { get; set; } = DateTime.Now;

        private async Task AddRace()
        {
            Race race = new Race();
         
            race.DateRace = Date;
            race.TrackRace = Track;
            if (race.TrackRace == null)
            {
                modal.Show<ErrorPopUp>("Грешка");
            }
            else
            {
                context.Races.Add(race);
                context.SaveChanges();
            }
            await OnInitializedAsync();
        }

        private async Task RemoveRace(Race race)
        {

            context.Races.Remove(race);
            context.SaveChanges();
            await OnInitializedAsync();
        }
        private async Task UpdateRace(Race race)
        {
            if (race.TrackRace == null)
            {
                modal.Show<ErrorPopUp>("Грешка");
            }
            else
            {
                context.Races.Update(race);
                context.SaveChanges();
                Track = null;
                Date = DateTime.Now;
            }
            await OnInitializedAsync();
        }
        protected override async Task OnInitializedAsync()
        {
           
            var query = context.Races.ToList();
            races = query;

        }
    }
}
