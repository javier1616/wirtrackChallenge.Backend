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
                columns: new[] { "Id", "CountryCode", "IsDeleted", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, "AR", false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(7326), "Palermo" },
                    { 2, "AR", false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(7382), "Belgrano" },
                    { 3, "AR", false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(7385), "Balvanera" },
                    { 4, "AR", false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(7387), "Retiro" },
                    { 5, "AR", false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(7390), "Avellaneda" },
                    { 6, "AR", false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(7392), "Quilmes" },
                    { 7, "AR", false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(7395), "Berazategui" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarLicense", "IsDeleted", "LastModified", "Model", "Type" },
                values: new object[,]
                {
                    { 1, "AAA000", false, new DateTime(2022, 9, 11, 14, 1, 12, 465, DateTimeKind.Utc).AddTicks(3376), "Peugeot 208", "car" },
                    { 2, "AAA001", false, new DateTime(2022, 9, 11, 14, 1, 12, 465, DateTimeKind.Utc).AddTicks(3760), "Mercedes Benz", "truck" },
                    { 3, "AAA002", false, new DateTime(2022, 9, 11, 14, 1, 12, 465, DateTimeKind.Utc).AddTicks(3770), "Honda CG 125", "motorcycle" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "DateTrip", "IdDestinationCity", "IdStatus", "IdVehicle", "IsDeleted", "LastModified" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(9211) },
                    { 7, new DateTime(2022, 9, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(9293) },
                    { 2, new DateTime(2022, 9, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2, false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(9278) },
                    { 3, new DateTime(2022, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 2, false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(9281) },
                    { 6, new DateTime(2022, 9, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(9290) },
                    { 4, new DateTime(2022, 9, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(9284) },
                    { 5, new DateTime(2022, 9, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 3, false, new DateTime(2022, 9, 11, 14, 1, 12, 466, DateTimeKind.Utc).AddTicks(9287) }
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
