using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSRSHelper.Migrations
{
    /// <inheritdoc />
    public partial class initialfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmSpots_FarmTypes_FarmTypeId",
                table: "FarmSpots");

            migrationBuilder.AlterColumn<int>(
                name: "FarmTypeId",
                table: "FarmSpots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmSpots_FarmTypes_FarmTypeId",
                table: "FarmSpots",
                column: "FarmTypeId",
                principalTable: "FarmTypes",
                principalColumn: "FarmTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmSpots_FarmTypes_FarmTypeId",
                table: "FarmSpots");

            migrationBuilder.AlterColumn<int>(
                name: "FarmTypeId",
                table: "FarmSpots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FarmSpots_FarmTypes_FarmTypeId",
                table: "FarmSpots",
                column: "FarmTypeId",
                principalTable: "FarmTypes",
                principalColumn: "FarmTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
