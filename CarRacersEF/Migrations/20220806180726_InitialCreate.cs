using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRacersEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelCar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrandCar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MileageCar = table.Column<int>(type: "int", nullable: false),
                    ServiceDateCar = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    IdDriver = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNameDriver = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SecondNameDriver = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastNameDriver = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    AgeDriver = table.Column<int>(type: "int", nullable: false),
                    NationalityDriver = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PointsDriver = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.IdDriver);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    IdRace = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackRace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRace = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.IdRace);
                });

            migrationBuilder.CreateTable(
                name: "RacesDriversCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    CarIdCar = table.Column<int>(type: "int", nullable: false),
                    IdDriver = table.Column<int>(type: "int", nullable: false),
                    DriverIdDriver = table.Column<int>(type: "int", nullable: false),
                    IdRace = table.Column<int>(type: "int", nullable: false),
                    RaceIdRace = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacesDriversCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RacesDriversCars_Cars_CarIdCar",
                        column: x => x.CarIdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacesDriversCars_Drivers_DriverIdDriver",
                        column: x => x.DriverIdDriver,
                        principalTable: "Drivers",
                        principalColumn: "IdDriver",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacesDriversCars_Races_RaceIdRace",
                        column: x => x.RaceIdRace,
                        principalTable: "Races",
                        principalColumn: "IdRace",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "IdCar", "BrandCar", "MileageCar", "ModelCar", "ServiceDateCar" },
                values: new object[,]
                {
                    { 1, "Porsche", 234, "956", new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Audi", 234, "R8", new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Skyline", 234, "GT-R R32", new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Penske", 234, "PC-23", new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "McLaren", 234, "M8", new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "IdDriver", "AgeDriver", "FirstNameDriver", "LastNameDriver", "NationalityDriver", "PointsDriver", "SecondNameDriver" },
                values: new object[,]
                {
                    { 1, 19, "Александър", "Иванов", "България", 12, "Теодоров" },
                    { 2, 20, "Петър", "Ангелов", "България", 43, "Николов" },
                    { 3, 29, "Hans", "Moritz", "Германия", 98, "Florian" },
                    { 4, 25, "Виолета", "Денева", "България", 2, "Теодорова" },
                    { 5, 19, "Николай", "Драгиев", "България", 0, "Петров" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "IdRace", "DateRace", "TrackRace" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monte Carlo" },
                    { 2, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autodromo Nazionale di Monza" },
                    { 3, new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Circuit de Spa-Francorchamps" },
                    { 4, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nurburgring Nordschleife" },
                    { 5, new DateTime(2021, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Circuit de la Sarthe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RacesDriversCars_CarIdCar",
                table: "RacesDriversCars",
                column: "CarIdCar");

            migrationBuilder.CreateIndex(
                name: "IX_RacesDriversCars_DriverIdDriver",
                table: "RacesDriversCars",
                column: "DriverIdDriver");

            migrationBuilder.CreateIndex(
                name: "IX_RacesDriversCars_RaceIdRace",
                table: "RacesDriversCars",
                column: "RaceIdRace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RacesDriversCars");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
