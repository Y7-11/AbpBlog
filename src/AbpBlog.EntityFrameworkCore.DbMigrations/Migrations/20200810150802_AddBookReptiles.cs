using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpBlog.Migrations
{
    public partial class AddBookReptiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abp_BookReptiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReptilesCount = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    ContentUrl = table.Column<string>(maxLength: 200, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abp_BookReptiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abp_BookReptiles");
        }
    }
}
