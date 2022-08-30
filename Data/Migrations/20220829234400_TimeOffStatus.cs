using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeOffApp.Data.Migrations
{
    public partial class TimeOffStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TimeOffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TimeOffs");
        }
    }
}
