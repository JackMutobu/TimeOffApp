using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeOffApp.Data.Migrations
{
    public partial class UpdateForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffs_AspNetUsers_UserId",
                table: "TimeOffs");

            migrationBuilder.DropIndex(
                name: "IX_TimeOffs_UserId",
                table: "TimeOffs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TimeOffs");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedById",
                table: "TimeOffs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeOffs_ApprovedById",
                table: "TimeOffs",
                column: "ApprovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffs_AspNetUsers_ApprovedById",
                table: "TimeOffs",
                column: "ApprovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffs_AspNetUsers_ApprovedById",
                table: "TimeOffs");

            migrationBuilder.DropIndex(
                name: "IX_TimeOffs_ApprovedById",
                table: "TimeOffs");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "TimeOffs");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TimeOffs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOffs_UserId",
                table: "TimeOffs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffs_AspNetUsers_UserId",
                table: "TimeOffs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
