using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetPress.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ImagesWH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Pictures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Pictures",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Format",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Pictures");
        }
    }
}
