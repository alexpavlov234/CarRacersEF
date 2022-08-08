using Blazored.Modal;
using CarRacersEF.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

namespace CarRacersEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            //Service за попъо
            builder.Services.AddBlazoredModal();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}