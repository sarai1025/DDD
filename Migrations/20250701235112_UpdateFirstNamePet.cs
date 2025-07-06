using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsFoundation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFirstNamePet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirtName",
                table: "Pets",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Pets",
                newName: "FirtName");
        }
    }
}
