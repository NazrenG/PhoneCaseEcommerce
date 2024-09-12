using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneCaseEcommerce.Entities.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Colors__3214EC07A5C8477E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__3214EC07D8C9EBC5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC07B9C0DEFC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vendors__3214EC0792E6B697", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserImag__3214EC078C88E55D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UserImage__UserI__403A8C7D",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Models__3214EC07E0721634", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Models__VendorId__3A81B327",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhoneCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellCount = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Premium = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Simple"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhoneCas__3214EC07D9FE143C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PhoneCase__Model__46E78A0C",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PhoneCase__UserI__47DBAE45",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PhoneCase__Vendo__45F365D3",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PhoneCaseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__3214EC071F8C1D69", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Cart__PhoneCaseI__5FB337D6",
                        column: x => x.PhoneCaseId,
                        principalTable: "PhoneCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Cart__UserId__5EBF139D",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneCaseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__3214EC07155F73D1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Comments__PhoneC__5165187F",
                        column: x => x.PhoneCaseId,
                        principalTable: "PhoneCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Comments__UserId__52593CB8",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneCaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favorite__3214EC0798DA10ED", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Favorites__Phone__5535A963",
                        column: x => x.PhoneCaseId,
                        principalTable: "PhoneCases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PhoneCaseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__3214EC07C711508A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__59FA5E80",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Phone__5AEE82B9",
                        column: x => x.PhoneCaseId,
                        principalTable: "PhoneCases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhoneColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneCaseId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhoneCol__3214EC07F31D0FEE", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PhoneColo__Color__4E88ABD4",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PhoneColo__Phone__4D94879B",
                        column: x => x.PhoneCaseId,
                        principalTable: "PhoneCases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhotoImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneCaseId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhotoIma__3214EC0787A656C9", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PhotoImag__Phone__4AB81AF0",
                        column: x => x.PhoneCaseId,
                        principalTable: "PhoneCases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PhoneCaseId",
                table: "Cart",
                column: "PhoneCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PhoneCaseId",
                table: "Comments",
                column: "PhoneCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PhoneCaseId",
                table: "Favorites",
                column: "PhoneCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_VendorId",
                table: "Models",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PhoneCaseId",
                table: "OrderDetails",
                column: "PhoneCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCases_ModelId",
                table: "PhoneCases",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCases_UserId",
                table: "PhoneCases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCases_VendorId",
                table: "PhoneCases",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneColors_ColorId",
                table: "PhoneColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneColors_PhoneCaseId",
                table: "PhoneColors",
                column: "PhoneCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoImages_PhoneCaseId",
                table: "PhotoImages",
                column: "PhoneCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserId",
                table: "UserImages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PhoneColors");

            migrationBuilder.DropTable(
                name: "PhotoImages");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "PhoneCases");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
