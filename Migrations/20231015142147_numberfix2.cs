using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations
{
    /// <inheritdoc />
    public partial class numberfix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_UserProfiles_UserId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_UserId",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Adresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Adresses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_UserId",
                table: "Adresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_UserProfiles_UserId",
                table: "Adresses",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }
    }
}
