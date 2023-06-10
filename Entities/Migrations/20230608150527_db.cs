using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buyers",
                keyColumn: "buyerId",
                keyValue: new Guid("205970eb-5e30-4332-9ae4-bbf1ab7df89a"));

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "buyerId", "BuyerGender", "BuyerSigninStatus", "FirstName", "LastName", "Password", "PhoneNumber", "Role" },
                values: new object[] { new Guid("e8fbc20b-519f-48ac-ab53-75e29b9fde80"), 0, 0, "Admin", "Admin", "Admin", "12345678", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buyers",
                keyColumn: "buyerId",
                keyValue: new Guid("e8fbc20b-519f-48ac-ab53-75e29b9fde80"));

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "buyerId", "BuyerGender", "BuyerSigninStatus", "FirstName", "LastName", "Password", "PhoneNumber", "Role" },
                values: new object[] { new Guid("205970eb-5e30-4332-9ae4-bbf1ab7df89a"), 0, 0, "Admin", "Admin", "Admin", "12345678", 0 });
        }
    }
}
