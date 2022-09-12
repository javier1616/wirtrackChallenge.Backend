using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wirtrack.AccessData.Migrations
{
    public partial class Migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeatherCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarLicense = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDestinationCity = table.Column<int>(type: "int", nullable: false),
                    IdVehicle = table.Column<int>(type: "int", nullable: false),
                    DateTrip = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Cities_IdDestinationCity",
                        column: x => x.IdDestinationCity,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Vehicles_IdVehicle",
                        column: x => x.IdVehicle,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryCode", "IsDeleted", "LastModified", "Name", "WeatherCondition" },
                values: new object[,]
                {
                    { 1, "AR", false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(2367), "Palermo", null },
                    { 2, "AR", false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(2585), "Belgrano", null },
                    { 3, "AR", false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(2588), "Balvanera", null },
                    { 4, "AR", false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(2590), "Retiro", null },
                    { 5, "AR", false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(2592), "Avellaneda", null },
                    { 6, "AR", false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(2595), "Quilmes", null },
                    { 7, "AR", false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(2597), "Berazategui", null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarLicense", "IsDeleted", "LastModified", "Model", "Type" },
                values: new object[,]
                {
                    { 1, "AAA000", false, new DateTime(2022, 9, 12, 15, 0, 8, 741, DateTimeKind.Utc).AddTicks(7263), "Peugeot 208", "car" },
                    { 2, "AAA001", false, new DateTime(2022, 9, 12, 15, 0, 8, 741, DateTimeKind.Utc).AddTicks(7693), "Mercedes Benz", "truck" },
                    { 3, "AAA002", false, new DateTime(2022, 9, 12, 15, 0, 8, 741, DateTimeKind.Utc).AddTicks(7708), "Honda CG 125", "motorcycle" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "DateTrip", "IdDestinationCity", "IdStatus", "IdVehicle", "IsDeleted", "LastModified" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(8454) },
                    { 7, new DateTime(2022, 9, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(8629) },
                    { 2, new DateTime(2022, 9, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2, false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(8610) },
                    { 3, new DateTime(2022, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 2, false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(8615) },
                    { 6, new DateTime(2022, 9, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(8625) },
                    { 4, new DateTime(2022, 9, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(8618) },
                    { 5, new DateTime(2022, 9, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 3, false, new DateTime(2022, 9, 12, 15, 0, 8, 743, DateTimeKind.Utc).AddTicks(8622) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_IdDestinationCity",
                table: "Trips",
                column: "IdDestinationCity");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_IdVehicle",
                table: "Trips",
                column: "IdVehicle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
