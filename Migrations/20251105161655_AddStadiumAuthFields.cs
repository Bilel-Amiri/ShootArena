using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoot.Migrations
{
    /// <inheritdoc />
    public partial class AddStadiumAuthFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Stadiums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Stadiums");
        }
    }
}
