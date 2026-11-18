using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlanning.Migrations
{
    /// <inheritdoc />
    public partial class SeedDevUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Auth0Id", "Email", "FirstName", "LastName" },
                values: new object[] { 1, null, "dev@example.com", "Dev", "User" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
