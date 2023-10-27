using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations.Data
{
    /// <inheritdoc />
    public partial class ImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryImageEntity_Categories_CategoryId",
                table: "CategoryImageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryImageEntity_Images_ImageId",
                table: "CategoryImageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryImageEntity",
                table: "CategoryImageEntity");

            migrationBuilder.RenameTable(
                name: "CategoryImageEntity",
                newName: "CategoryImages");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryImageEntity_ImageId",
                table: "CategoryImages",
                newName: "IX_CategoryImages_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryImageEntity_CategoryId",
                table: "CategoryImages",
                newName: "IX_CategoryImages_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryImages",
                table: "CategoryImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryImages_Categories_CategoryId",
                table: "CategoryImages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryImages_Images_ImageId",
                table: "CategoryImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryImages_Categories_CategoryId",
                table: "CategoryImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryImages_Images_ImageId",
                table: "CategoryImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryImages",
                table: "CategoryImages");

            migrationBuilder.RenameTable(
                name: "CategoryImages",
                newName: "CategoryImageEntity");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryImages_ImageId",
                table: "CategoryImageEntity",
                newName: "IX_CategoryImageEntity_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryImages_CategoryId",
                table: "CategoryImageEntity",
                newName: "IX_CategoryImageEntity_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryImageEntity",
                table: "CategoryImageEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryImageEntity_Categories_CategoryId",
                table: "CategoryImageEntity",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryImageEntity_Images_ImageId",
                table: "CategoryImageEntity",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
