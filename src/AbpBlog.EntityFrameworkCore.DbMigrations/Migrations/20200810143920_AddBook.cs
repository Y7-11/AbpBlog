using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpBlog.Migrations
{
    public partial class AddBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abp_Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookId = table.Column<long>(maxLength: 20, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    ContentUrl = table.Column<string>(maxLength: 200, nullable: true),
                    WordsNumber = table.Column<int>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abp_Book", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abp_Book");
        }
    }
}
