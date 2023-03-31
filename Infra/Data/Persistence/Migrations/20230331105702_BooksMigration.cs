using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.Infra.Data.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BooksMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "TEXT", nullable: false),
                    author = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.BookId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
