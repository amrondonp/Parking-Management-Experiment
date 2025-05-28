using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMinutesCharged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinutesCharged",
                table: "ParkingSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinutesCharged",
                table: "ParkingSessions");
        }
    }
}
