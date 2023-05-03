using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "Category", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Subcategory", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c2f1fe2a-ce4a-4009-b099-196fea03cbf7", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "służbowy", "ed7d6c94-da72-428e-aadb-0fde3f49ea56", "admin@gmail.com", false, "admin", "admin", false, null, null, null, "AQAAAAEAACcQAAAAEDcxMkpv3FiT7GkU0nFyszPH9lug3PDyrLU3bs19jG1q4LZern9kT5lxGzO9C4KJjA==", "555654754", false, "6f851e6b-8b38-4eb2-a922-c22d1493fe7e", "szef", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f1fe2a-ce4a-4009-b099-196fea03cbf7");
        }
    }
}
