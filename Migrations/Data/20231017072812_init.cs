using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations.Data
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ImageEntity_ImageId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddressEntity_UserProfileEntity_UserId",
                table: "UserAddressEntity");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserPhoneNumbersEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageEntity",
                table: "ImageEntity");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserAddressEntity");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "UserAddressEntity");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "UserAddressEntity");

            migrationBuilder.RenameTable(
                name: "ImageEntity",
                newName: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserAddressEntity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "UserAddressEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AddressEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReviews_UserProfileEntity_ProfileUserId",
                        column: x => x.ProfileUserId,
                        principalTable: "UserProfileEntity",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressEntity_AddressId",
                table: "UserAddressEntity",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ArticleNumber",
                table: "ProductReviews",
                column: "ArticleNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProfileUserId",
                table: "ProductReviews",
                column: "ProfileUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Images_ImageId",
                table: "ProductImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddressEntity_AddressEntity_AddressId",
                table: "UserAddressEntity",
                column: "AddressId",
                principalTable: "AddressEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddressEntity_UserProfileEntity_UserId",
                table: "UserAddressEntity",
                column: "UserId",
                principalTable: "UserProfileEntity",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Images_ImageId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddressEntity_AddressEntity_AddressId",
                table: "UserAddressEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddressEntity_UserProfileEntity_UserId",
                table: "UserAddressEntity");

            migrationBuilder.DropTable(
                name: "AddressEntity");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_UserAddressEntity_AddressId",
                table: "UserAddressEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "UserAddressEntity");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ImageEntity");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserAddressEntity",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserAddressEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "UserAddressEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "UserAddressEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageEntity",
                table: "ImageEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_UserProfileEntity_ProfileUserId",
                        column: x => x.ProfileUserId,
                        principalTable: "UserProfileEntity",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserPhoneNumbersEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhoneNumbersEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhoneNumbersEntity_UserProfileEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfileEntity",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ArticleNumber",
                table: "Reviews",
                column: "ArticleNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProfileUserId",
                table: "Reviews",
                column: "ProfileUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhoneNumbersEntity_UserId",
                table: "UserPhoneNumbersEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ImageEntity_ImageId",
                table: "ProductImages",
                column: "ImageId",
                principalTable: "ImageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddressEntity_UserProfileEntity_UserId",
                table: "UserAddressEntity",
                column: "UserId",
                principalTable: "UserProfileEntity",
                principalColumn: "UserId");
        }
    }
}
