using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoot.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordHashToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Clients",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Clients",
                newName: "Password");
        }
    }
}
