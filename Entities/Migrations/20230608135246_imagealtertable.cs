using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class imagealtertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    authorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    BIO = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.authorId);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    buyerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    BuyerGender = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    BuyerSigninStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.buyerId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    genreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.genreId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    publisherId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.publisherId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ISBN = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cover = table.Column<int>(type: "integer", nullable: false),
                    Inscription = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    PagesCount = table.Column<int>(type: "integer", nullable: false),
                    publisherId = table.Column<int>(type: "integer", nullable: false),
                    authorId = table.Column<int>(type: "integer", nullable: true),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    genreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_authorId",
                        column: x => x.authorId,
                        principalTable: "Authors",
                        principalColumn: "authorId");
                    table.ForeignKey(
                        name: "FK_Books_Genres_genreId",
                        column: x => x.genreId,
                        principalTable: "Genres",
                        principalColumn: "genreId");
                    table.ForeignKey(
                        name: "FK_Books_Publishers_publisherId",
                        column: x => x.publisherId,
                        principalTable: "Publishers",
                        principalColumn: "publisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    bookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "buyerId", "BuyerGender", "BuyerSigninStatus", "FirstName", "LastName", "Password", "PhoneNumber", "Role" },
                values: new object[] { new Guid("205970eb-5e30-4332-9ae4-bbf1ab7df89a"), 0, 0, "Admin", "Admin", "Admin", "12345678", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_authorId",
                table: "Books",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_genreId",
                table: "Books",
                column: "genreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_publisherId",
                table: "Books",
                column: "publisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_bookId",
                table: "Images",
                column: "bookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
