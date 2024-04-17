using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPosta.DataAccess.Migrations
{
    public partial class mig_NameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "AppMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "AppMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "AppMessages");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "AppMessages");
        }
    }
}
