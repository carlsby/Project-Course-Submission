using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations.Data
{
    /// <inheritdoc />
    public partial class ProductReviewId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewEntityId",
                table: "ProductReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ReviewEntityId",
                table: "ProductReviews",
                column: "ReviewEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Reviews_ReviewEntityId",
                table: "ProductReviews",
                column: "ReviewEntityId",
                principalTable: "Reviews",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Reviews_ReviewEntityId",
                table: "ProductReviews");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_ReviewEntityId",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "ReviewEntityId",
                table: "ProductReviews");
        }
    }
}
