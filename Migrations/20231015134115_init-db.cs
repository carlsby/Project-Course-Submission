using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_UserProfiles_UserId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneNumber_UserProfiles_UserId",
                table: "UserPhoneNumber");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "UserPhoneNumber");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserPhoneNumber");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "UserAddress");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPhoneNumber",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberId",
                table: "UserPhoneNumber",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserAddress",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "UserAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AddressEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressEntity_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumberEntity_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPhoneNumber_PhoneNumberId",
                table: "UserPhoneNumber",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_AddressId",
                table: "UserAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntity_UserId",
                table: "AddressEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumberEntity_UserId",
                table: "PhoneNumberEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AddressEntity_AddressId",
                table: "UserAddress",
                column: "AddressId",
                principalTable: "AddressEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_UserProfiles_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumber_PhoneNumberEntity_PhoneNumberId",
                table: "UserPhoneNumber",
                column: "PhoneNumberId",
                principalTable: "PhoneNumberEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumber_UserProfiles_UserId",
                table: "UserPhoneNumber",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AddressEntity_AddressId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_UserProfiles_UserId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneNumber_PhoneNumberEntity_PhoneNumberId",
                table: "UserPhoneNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneNumber_UserProfiles_UserId",
                table: "UserPhoneNumber");

            migrationBuilder.DropTable(
                name: "AddressEntity");

            migrationBuilder.DropTable(
                name: "PhoneNumberEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserPhoneNumber_PhoneNumberId",
                table: "UserPhoneNumber");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_AddressId",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "PhoneNumberId",
                table: "UserPhoneNumber");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "UserAddress");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPhoneNumber",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "UserPhoneNumber",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserPhoneNumber",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserAddress",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserAddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "UserAddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "UserAddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_UserProfiles_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumber_UserProfiles_UserId",
                table: "UserPhoneNumber",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }
    }
}
