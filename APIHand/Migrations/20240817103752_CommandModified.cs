using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIHand.Migrations
{
    /// <inheritdoc />
    public partial class CommandModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sheet_pk",
                table: "Commands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sheet_pk",
                table: "Commands");
        }
    }
}
