using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSA.Phase2.API.Migrations
{
    public partial class SeedInitalDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Ash" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Brock" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "May" });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "CodexNumber", "Name", "TrainerId", "TrainerName", "Types" },
                values: new object[] { 1, 25, "pikachu", 1, "Ash", "electric" });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "CodexNumber", "Name", "TrainerId", "TrainerName", "Types" },
                values: new object[] { 2, 205, "forretress", 2, "Brock", "bug, steel" });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "CodexNumber", "Name", "TrainerId", "TrainerName", "Types" },
                values: new object[] { 3, 255, "torchic", 3, "May", "fire" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
