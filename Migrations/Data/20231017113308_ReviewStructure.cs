using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations.Data
{
    /// <inheritdoc />
    public partial class ReviewStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Reviews_ReviewEntityId",
                table: "ProductReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_UserProfileEntity_ProfileUserId",
                table: "ProductReviews");

            migrationBuilder.DropTable(
                name: "UserAddressEntity");

            migrationBuilder.DropTable(
                name: "AddressEntity");

            migrationBuilder.DropTable(
                name: "UserProfileEntity");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductReviews",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_ArticleNumber",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_ProfileUserId",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_ReviewEntityId",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "CommentCreated",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "ProfileUserId",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "ReviewEntityId",
                table: "ProductReviews");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "ProductReviews",
                newName: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductReviews",
                table: "ProductReviews",
                columns: new[] { "ArticleNumber", "ReviewId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ReviewId",
                table: "ProductReviews",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Reviews_ReviewId",
                table: "ProductReviews",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Reviews_ReviewId",
                table: "ProductReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductReviews",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_ReviewId",
                table: "ProductReviews");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "ProductReviews",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductReviews",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ProductReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentCreated",
                table: "ProductReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProfileUserId",
                table: "ProductReviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewEntityId",
                table: "ProductReviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductReviews",
                table: "ProductReviews",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AddressEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileEntity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileEntity", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserProfileEntity_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddressEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddressEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddressEntity_AddressEntity_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddressEntity_UserProfileEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfileEntity",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ArticleNumber",
                table: "ProductReviews",
                column: "ArticleNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProfileUserId",
                table: "ProductReviews",
                column: "ProfileUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ReviewEntityId",
                table: "ProductReviews",
                column: "ReviewEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressEntity_AddressId",
                table: "UserAddressEntity",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressEntity_UserId",
                table: "UserAddressEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Reviews_ReviewEntityId",
                table: "ProductReviews",
                column: "ReviewEntityId",
                principalTable: "Reviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_UserProfileEntity_ProfileUserId",
                table: "ProductReviews",
                column: "ProfileUserId",
                principalTable: "UserProfileEntity",
                principalColumn: "UserId");
        }
    }
}
