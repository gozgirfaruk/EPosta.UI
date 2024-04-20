using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPosta.DataAccess.Migrations
{
    public partial class mig_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AppMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AppMessages");
        }
    }
}
