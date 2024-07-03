using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName", "PhoneNumber", "Position" },
                values: new object[,]
                {
                    { new Guid("a2785e7f-17d1-4936-acf1-3b8631e9bb22"), "Engineering", "john.doe@example.com", "John", "Doe", "1234567890", "Software Engineer" },
                    { new Guid("d7773ab7-0deb-4012-90bd-4bf55354465e"), "Product", "jane.smith@example.com", "Jane", "Smith", "0987654321", "Product Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a2785e7f-17d1-4936-acf1-3b8631e9bb22"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("d7773ab7-0deb-4012-90bd-4bf55354465e"));
        }
    }
}
