using CarRacersEF.Data;
using CarRacersEF.Models;
using Microsoft.AspNetCore.Components;

namespace CarRacersEF.Pages
{
    public partial class Ranking
    {
        List<Driver> drivers;
        [Inject]
        CarContext context { get; set; } = default;
        protected override async Task OnInitializedAsync()
        {

            var query = context.Drivers.OrderByDescending(f => f.PointsDriver).ToList();
            drivers = query;
        }
    }


}
