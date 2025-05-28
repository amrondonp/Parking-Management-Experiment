using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMoneyProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RatePerMinute",
                table: "ParkingSessions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "ParkingSessions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Taxes",
                table: "ParkingSessions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "ParkingSessions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatePerMinute",
                table: "ParkingSessions");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "ParkingSessions");

            migrationBuilder.DropColumn(
                name: "Taxes",
                table: "ParkingSessions");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "ParkingSessions");
        }
    }
}
