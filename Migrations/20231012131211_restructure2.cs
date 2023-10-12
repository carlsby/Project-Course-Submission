using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations
{
    /// <inheritdoc />
    public partial class restructure2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneNumberEntity_UserProfiles_UserId",
                table: "UserPhoneNumberEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPhoneNumberEntity",
                table: "UserPhoneNumberEntity");

            migrationBuilder.RenameTable(
                name: "UserPhoneNumberEntity",
                newName: "UserPhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_UserPhoneNumberEntity_UserId",
                table: "UserPhoneNumber",
                newName: "IX_UserPhoneNumber_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPhoneNumber",
                table: "UserPhoneNumber",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumber_UserProfiles_UserId",
                table: "UserPhoneNumber",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneNumber_UserProfiles_UserId",
                table: "UserPhoneNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPhoneNumber",
                table: "UserPhoneNumber");

            migrationBuilder.RenameTable(
                name: "UserPhoneNumber",
                newName: "UserPhoneNumberEntity");

            migrationBuilder.RenameIndex(
                name: "IX_UserPhoneNumber_UserId",
                table: "UserPhoneNumberEntity",
                newName: "IX_UserPhoneNumberEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPhoneNumberEntity",
                table: "UserPhoneNumberEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumberEntity_UserProfiles_UserId",
                table: "UserPhoneNumberEntity",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }
    }
}
