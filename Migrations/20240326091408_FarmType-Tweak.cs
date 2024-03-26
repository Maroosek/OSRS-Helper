using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSRSHelper.Migrations
{
    /// <inheritdoc />
    public partial class FarmTypeTweak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionTime",
                table: "FarmTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionTime",
                table: "FarmTypes");
        }
    }
}
