using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSA.Phase2.API.Migrations
{
    public partial class ChangePokemonDetailsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Types",
                table: "Pokemons");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Height", "Weight" },
                values: new object[] { 4, 60 });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Height", "Weight" },
                values: new object[] { 12, 1258 });

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Height", "Weight" },
                values: new object[] { 4, 25 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Pokemons");

            migrationBuilder.AddColumn<string>(
                name: "Types",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Types",
                value: "electric");

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Types",
                value: "bug, steel");

            migrationBuilder.UpdateData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3,
                column: "Types",
                value: "fire");
        }
    }
}
