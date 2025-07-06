using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsFoundation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interested",
                columns: table => new
                {
                    kInterested = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdentificationType = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Interest__85479F705954CEA0", x => x.kInterested);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    kPet = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentificationNumber = table.Column<int>(type: "int", nullable: false),
                    FirtName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PetType = table.Column<int>(type: "int", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    kGodFather = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    kOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pets__DFC35C4A79DFE013", x => x.kPet);
                    table.ForeignKey(
                        name: "FK__Pets__kGodFather__412EB0B6",
                        column: x => x.kGodFather,
                        principalTable: "Interested",
                        principalColumn: "kInterested");
                    table.ForeignKey(
                        name: "FK__Pets__kOwner__4222D4EF",
                        column: x => x.kOwner,
                        principalTable: "Interested",
                        principalColumn: "kInterested");
                });

            migrationBuilder.CreateTable(
                name: "AdoptionRequests",
                columns: table => new
                {
                    kAdoptionRequest = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    kPet = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    kInterested = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    KPetNavigationKPet = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Adoption__F5B827EB4C37596D", x => x.kAdoptionRequest);
                    table.ForeignKey(
                        name: "FK_AdoptionRequests_Pets_KPetNavigationKPet",
                        column: x => x.KPetNavigationKPet,
                        principalTable: "Pets",
                        principalColumn: "kPet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__AdoptionR__kInte__4AB81AF0",
                        column: x => x.kInterested,
                        principalTable: "Interested",
                        principalColumn: "kInterested");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_kInterested",
                table: "AdoptionRequests",
                column: "kInterested");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_KPetNavigationKPet",
                table: "AdoptionRequests",
                column: "KPetNavigationKPet");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_kGodFather",
                table: "Pets",
                column: "kGodFather");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_kOwner",
                table: "Pets",
                column: "kOwner");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionRequests");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Interested");
        }
    }
}
