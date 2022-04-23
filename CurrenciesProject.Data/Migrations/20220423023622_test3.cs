using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrenciesProject.Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanknoteSelling",
                table: "Currencies");

            migrationBuilder.AddColumn<double>(
                name: "ForexSelling",
                table: "Currencies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForexSelling",
                table: "Currencies");

            migrationBuilder.AddColumn<string>(
                name: "BanknoteSelling",
                table: "Currencies",
                type: "text",
                nullable: true);
        }
    }
}
