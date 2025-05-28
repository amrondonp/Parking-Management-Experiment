using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameToCsharp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_parkingSessions",
                table: "parkingSessions");

            migrationBuilder.RenameTable(
                name: "parkingSessions",
                newName: "ParkingSessions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingSessions",
                table: "ParkingSessions",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingSessions",
                table: "ParkingSessions");

            migrationBuilder.RenameTable(
                name: "ParkingSessions",
                newName: "parkingSessions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parkingSessions",
                table: "parkingSessions",
                column: "Id");
        }
    }
}
