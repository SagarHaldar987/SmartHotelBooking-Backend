using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddManagerIdToRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ManagerId",
                table: "Rooms",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_ManagerId",
                table: "Rooms",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_ManagerId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ManagerId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Rooms");
        }
    }
}
