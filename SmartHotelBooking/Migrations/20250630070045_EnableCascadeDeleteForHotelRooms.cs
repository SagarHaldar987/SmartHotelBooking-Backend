using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class EnableCascadeDeleteForHotelRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Rooms__HotelID__3D5E1FD2",
                table: "Rooms");

            migrationBuilder.AddForeignKey(
                name: "FK__Rooms__HotelID__3D5E1FD2",
                table: "Rooms",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Rooms__HotelID__3D5E1FD2",
                table: "Rooms");

            migrationBuilder.AddForeignKey(
                name: "FK__Rooms__HotelID__3D5E1FD2",
                table: "Rooms",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "HotelID");
        }
    }
}
