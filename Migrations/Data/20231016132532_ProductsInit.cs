using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations.Data
{
    /// <inheritdoc />
    public partial class ProductsInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_UserProfileEntity_UserId1",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Reviews",
                newName: "ProfileUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId1",
                table: "Reviews",
                newName: "IX_Reviews_ProfileUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_UserProfileEntity_ProfileUserId",
                table: "Reviews",
                column: "ProfileUserId",
                principalTable: "UserProfileEntity",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_UserProfileEntity_ProfileUserId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ProfileUserId",
                table: "Reviews",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProfileUserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_UserProfileEntity_UserId1",
                table: "Reviews",
                column: "UserId1",
                principalTable: "UserProfileEntity",
                principalColumn: "UserId");
        }
    }
}
