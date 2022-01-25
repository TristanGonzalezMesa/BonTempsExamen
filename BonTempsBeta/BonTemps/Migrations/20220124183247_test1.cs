using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GerechtSoorten",
                columns: new[] { "Id", "Soort" },
                values: new object[,]
                {
                    { 1, "VoorGerecht" },
                    { 2, "HoofdGerecht" },
                    { 3, "NaGerecht" },
                    { 4, "Drank" }
                });

            migrationBuilder.InsertData(
                table: "Gerechten",
                columns: new[] { "Id", "GerechtSoortId", "Naam" },
                values: new object[,]
                {
                    { 1, 2, "Biefstuk" },
                    { 2, 1, "Carpaccio" },
                    { 3, 3, "Vanilleijs" }
                });

            migrationBuilder.InsertData(
                table: "Ingredienten",
                columns: new[] { "Id", "Eenheid", "Naam" },
                values: new object[,]
                {
                    { 1, "500 gram", "Vlees" },
                    { 2, "250 gram", "Rundercarpaccio" },
                    { 3, "10 gram", "Pijnboompit" },
                    { 4, "100 gram", "Ijs" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Naam", "Prijs" },
                values: new object[,]
                {
                    { 1, "HerfstMenu", 24m },
                    { 2, "KerstMenu", 23m },
                    { 3, "FeestMenu", 20m }
                });

            migrationBuilder.InsertData(
                table: "Reserveringen",
                columns: new[] { "Id", "AantalPersonen", "Datum", "KlantId", "Tijd" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ReserveringMenus",
                columns: new[] { "MenuId", "ReserveringId", "Aantal" },
                values: new object[] { 1, 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GerechtSoorten",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GerechtSoorten",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GerechtSoorten",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GerechtSoorten",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gerechten",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredienten",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReserveringMenus",
                keyColumns: new[] { "MenuId", "ReserveringId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reserveringen",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
