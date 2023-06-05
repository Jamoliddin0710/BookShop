using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class initfb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Sellers_sellerId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Books_sellerId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Buyers",
                keyColumn: "buyerId",
                keyValue: new Guid("8ee5ee6a-bf0d-4987-aedc-2d7c1b938f05"));

            migrationBuilder.DropColumn(
                name: "sellerId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "buyerId", "BuyerGender", "BuyerSigninStatus", "FirstName", "LastName", "Password", "PhoneNumber", "Role" },
                values: new object[] { new Guid("70d07670-9cae-464c-8b16-e95fd38eeedc"), 0, 0, "Admin", "Admin", "Admin", "12345678", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buyers",
                keyColumn: "buyerId",
                keyValue: new Guid("70d07670-9cae-464c-8b16-e95fd38eeedc"));

            migrationBuilder.AddColumn<Guid>(
                name: "sellerId",
                table: "Books",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    sellerId = table.Column<Guid>(type: "uuid", nullable: false),
                    publisherId = table.Column<int>(type: "integer", nullable: true),
                    BuyerGender = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Steps = table.Column<int>(type: "integer", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.sellerId);
                    table.ForeignKey(
                        name: "FK_Sellers_Publishers_publisherId",
                        column: x => x.publisherId,
                        principalTable: "Publishers",
                        principalColumn: "publisherId");
                });

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "buyerId", "BuyerGender", "BuyerSigninStatus", "FirstName", "LastName", "Password", "PhoneNumber", "Role" },
                values: new object[] { new Guid("8ee5ee6a-bf0d-4987-aedc-2d7c1b938f05"), 0, 0, "Admin", "Admin", "Admin", "12345678", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_sellerId",
                table: "Books",
                column: "sellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_publisherId",
                table: "Sellers",
                column: "publisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Sellers_sellerId",
                table: "Books",
                column: "sellerId",
                principalTable: "Sellers",
                principalColumn: "sellerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
