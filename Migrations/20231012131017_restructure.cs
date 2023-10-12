using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations
{
    /// <inheritdoc />
    public partial class restructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_UserProfiles_UserProfileEntityUserId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneNumberEntity_UserProfiles_UserProfileEntityUserId",
                table: "UserPhoneNumberEntity");

            migrationBuilder.RenameColumn(
                name: "UserProfileEntityUserId",
                table: "UserPhoneNumberEntity",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPhoneNumberEntity_UserProfileEntityUserId",
                table: "UserPhoneNumberEntity",
                newName: "IX_UserPhoneNumberEntity_UserId");

            migrationBuilder.RenameColumn(
                name: "UserProfileEntityUserId",
                table: "UserAddress",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_UserProfileEntityUserId",
                table: "UserAddress",
                newName: "IX_UserAddress_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_UserProfiles_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumberEntity_UserProfiles_UserId",
                table: "UserPhoneNumberEntity",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_UserProfiles_UserId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPhoneNumberEntity_UserProfiles_UserId",
                table: "UserPhoneNumberEntity");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPhoneNumberEntity",
                newName: "UserProfileEntityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPhoneNumberEntity_UserId",
                table: "UserPhoneNumberEntity",
                newName: "IX_UserPhoneNumberEntity_UserProfileEntityUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserAddress",
                newName: "UserProfileEntityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress",
                newName: "IX_UserAddress_UserProfileEntityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_UserProfiles_UserProfileEntityUserId",
                table: "UserAddress",
                column: "UserProfileEntityUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumberEntity_UserProfiles_UserProfileEntityUserId",
                table: "UserPhoneNumberEntity",
                column: "UserProfileEntityUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }
    }
}
