using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrenciesProject.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "ForexBuying",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "ForexSelling",
                table: "Currencies",
                newName: "BanknoteSelling");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BanknoteSelling",
                table: "Currencies",
                newName: "ForexSelling");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyName",
                table: "Currencies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ForexBuying",
                table: "Currencies",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Currencies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
