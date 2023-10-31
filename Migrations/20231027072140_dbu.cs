using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Course_Submission.Migrations
{
    /// <inheritdoc />
    public partial class dbu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ArticleNumber);
                });

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

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
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
                name: "CategoryImageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryImageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryImageEntity_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryImageEntity_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ArticleNumber, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    IsDefaultImage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ArticleNumber, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ProductImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviewEntity",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviewEntity", x => new { x.ArticleNumber, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_ProductReviewEntity_Products_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReviewEntity_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ArticleNumber, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfileEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfileEntity",
                        principalColumn: "UserId",
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

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductReview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductReviewRate = table.Column<int>(type: "int", nullable: false),
                    ProductsArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlist_Products_ProductsArticleNumber",
                        column: x => x.ProductsArticleNumber,
                        principalTable: "Products",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlist_UserProfileEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfileEntity",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemEntity",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemEntity", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItemEntity_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDot = table.Column<bool>(type: "bit", nullable: false),
                    IsLine = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TrackLabel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_Tracks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImageEntity_CategoryId",
                table: "CategoryImageEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImageEntity_ImageId",
                table: "CategoryImageEntity",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemEntity_OrderId",
                table: "OrderItemEntity",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ImageId",
                table: "ProductImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewEntity_ReviewId",
                table: "ProductReviewEntity",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_OrderId",
                table: "Tracks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressEntity_AddressId",
                table: "UserAddressEntity",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddressEntity_UserId",
                table: "UserAddressEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_ProductsArticleNumber",
                table: "Wishlist",
                column: "ProductsArticleNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryImageEntity");

            migrationBuilder.DropTable(
                name: "OrderItemEntity");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductReviewEntity");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "UserAddressEntity");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AddressEntity");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserProfileEntity");

            migrationBuilder.DropTable(
                name: "IdentityUser");
        }
    }
}
