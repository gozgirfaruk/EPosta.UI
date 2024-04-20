using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPosta.DataAccess.Migrations
{
    public partial class mig_statusForDraft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Drafts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Drafts");
        }
    }
}
