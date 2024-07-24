using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizzWeb.Migrations
{
    /// <inheritdoc />
    public partial class addQuizzAndQuetionTBandSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Math Questions" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "QuizId" },
                values: new object[,]
                {
                    { 1, " 2+3=?", 1 },
                    { 2, "3*3=?", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
