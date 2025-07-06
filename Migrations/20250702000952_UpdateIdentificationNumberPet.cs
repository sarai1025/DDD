using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsFoundation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentificationNumberPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "IdentificationNumber");

            migrationBuilder.AlterColumn<int>(
                name: "IdentificationNumber",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR IdentificationNumber",
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "IdentificationNumber");

            migrationBuilder.AlterColumn<int>(
                name: "IdentificationNumber",
                table: "Pets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR IdentificationNumber");
        }
    }
}
