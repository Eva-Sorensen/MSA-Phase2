using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSA.Phase2.API.Migrations
{
    public partial class UpdateDataNamesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Trainers");

            migrationBuilder.AddColumn<int>(
                name: "CodexNumber",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodexNumber",
                table: "Pokemons");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
