using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations
{
    /// <inheritdoc />
    public partial class numberfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressEntity_UserProfiles_UserId",
                table: "AddressEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumberEntity_UserProfiles_UserId",
                table: "PhoneNumberEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AddressEntity_AddressId",
                table: "UserAddress");

            migrationBuilder.DropTable(
                name: "UserPhoneNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumberEntity",
                table: "PhoneNumberEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressEntity",
                table: "AddressEntity");

            migrationBuilder.RenameTable(
                name: "PhoneNumberEntity",
                newName: "PhoneNumbers");

            migrationBuilder.RenameTable(
                name: "AddressEntity",
                newName: "Adresses");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumberEntity_UserId",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressEntity_UserId",
                table: "Adresses",
                newName: "IX_Adresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumbers",
                table: "PhoneNumbers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_UserProfiles_UserId",
                table: "Adresses",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_UserProfiles_UserId",
                table: "PhoneNumbers",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Adresses_AddressId",
                table: "UserAddress",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_UserProfiles_UserId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_UserProfiles_UserId",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Adresses_AddressId",
                table: "UserAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumbers",
                table: "PhoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.RenameTable(
                name: "PhoneNumbers",
                newName: "PhoneNumberEntity");

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "AddressEntity");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumbers_UserId",
                table: "PhoneNumberEntity",
                newName: "IX_PhoneNumberEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Adresses_UserId",
                table: "AddressEntity",
                newName: "IX_AddressEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumberEntity",
                table: "PhoneNumberEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressEntity",
                table: "AddressEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserPhoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhoneNumber_PhoneNumberEntity_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumberEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPhoneNumber_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPhoneNumber_PhoneNumberId",
                table: "UserPhoneNumber",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhoneNumber_UserId",
                table: "UserPhoneNumber",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressEntity_UserProfiles_UserId",
                table: "AddressEntity",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumberEntity_UserProfiles_UserId",
                table: "PhoneNumberEntity",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AddressEntity_AddressId",
                table: "UserAddress",
                column: "AddressId",
                principalTable: "AddressEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
