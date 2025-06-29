using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStatusToBoolInBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Bookings",
                type: "bit",
                maxLength: 50,
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Bookings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 50);
        }
    }
}
