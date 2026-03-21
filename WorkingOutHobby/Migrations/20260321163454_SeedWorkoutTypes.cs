using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkingOutHobby.Migrations
{
    /// <inheritdoc />
    public partial class SeedWorkoutTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Strength" },
                    { 2, "Cardio" },
                    { 3, "HIIT" },
                    { 4, "Flexibility" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
