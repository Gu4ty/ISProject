using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISProject.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true),
                    ProductSaleID = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SellerId = table.Column<string>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Seen = table.Column<bool>(nullable: false),
                    CurrentPrice = table.Column<double>(nullable: false),
                    PriceStep = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionHeader_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    OrderTime = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeader_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    SellerId = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSale_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSale_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    AuctionId = table.Column<int>(nullable: false),
                    LastPriceOffered = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionUser_AuctionHeader_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SendToUser = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    NotiDate = table.Column<DateTime>(nullable: false),
                    Seen = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    AuctionHeaderID = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    OrderHeaderID = table.Column<int>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_AuctionHeader_AuctionHeaderID",
                        column: x => x.AuctionHeaderID,
                        principalTable: "AuctionHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_OrderHeader_OrderHeaderID",
                        column: x => x.OrderHeaderID,
                        principalTable: "OrderHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuctionProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(nullable: false),
                    AuctionId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    NotiAuctionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionProduct_AuctionHeader_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionProduct_Notification_NotiAuctionId",
                        column: x => x.NotiAuctionId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuctionProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AmountLeft = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    NotiBuyId = table.Column<int>(nullable: true),
                    NotiSellId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Notification_NotiBuyId",
                        column: x => x.NotiBuyId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Notification_NotiSellId",
                        column: x => x.NotiSellId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeader_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProductSale_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductSale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Seller", "f306b766-42e2-48c8-8d42-c8ba91f0491f", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Manager", "d727cd73-b934-4c78-bf96-18dbd0624c51", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Customer", "3ff4d78d-c2a0-4e35-83b9-bc64a5a97679", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21123111111", 0, "e26f808a-4fa5-4641-9902-6bc89ed284e3", "User", "admin@fake.com", true, true, null, "ADMIN@FAKE.COM", "ADMIN@FAKE.COM", "AQAAAAEAACcQAAAAEP2C1uCjpD/lYgV/pqSqBXtv4rx2v0TBbjcjQ8uuduM+oub6/DUB56+rT4bd5TAVFA==", null, false, "d13ac3d3-88a5-47f7-96e3-bd67fe1d2594", false, "admin@fake.com", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "101", 0, "b27249ba-4ca0-4112-a658-159b3ba79010", "User", "Customer10@fake.com", true, true, null, "CUSTOMER10@FAKE.COM", "CUSTOMER10@FAKE.COM", "AQAAAAEAACcQAAAAEB4QTQwy8ua62Vkz+3sJJwg2voybC780WVFNeBugYfOwQorYR3k0bhtL+2eIbYqybQ==", null, false, "9fde8c63-376f-4c4c-99ca-2dac178aa72d", false, "Customer10@fake.com", "Customer10" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "91", 0, "cb90497e-56d4-42f0-94b1-5274b523bee6", "User", "Customer9@fake.com", true, true, null, "CUSTOMER9@FAKE.COM", "CUSTOMER9@FAKE.COM", "AQAAAAEAACcQAAAAEAkqD8bDbAfYUDbmXc9HLb9N4CzVIFQxQmWfptpGeUshcRnofoocd91MPgzvy/wNyA==", null, false, "b9ab8443-dc4d-42c4-9294-57898d8a519e", false, "Customer9@fake.com", "Customer9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "81", 0, "224f77aa-ac6f-4829-b00c-cff367242551", "User", "Customer8@fake.com", true, true, null, "CUSTOMER8@FAKE.COM", "CUSTOMER8@FAKE.COM", "AQAAAAEAACcQAAAAECLPXt26x3hT70xcONsQEpd8tcZJpVft0PKM4nKx8N509IyF1htrEjVLAiU2tr74EQ==", null, false, "17e1f70e-ef5f-46dc-a6a6-75bebdbc9e7c", false, "Customer8@fake.com", "Customer8" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "71", 0, "bef6d0d5-1707-4737-bbb3-ec5136783a7b", "User", "Customer7@fake.com", true, true, null, "CUSTOMER7@FAKE.COM", "CUSTOMER7@FAKE.COM", "AQAAAAEAACcQAAAAEHkj0Q/M0kg+TmNsdIgoeoXbmR2d1/w+Yk4MzPU3CmTVcfmU7aahTru39TSjBAvXzg==", null, false, "4b989be9-cf3a-4a57-b2be-23676c676fdf", false, "Customer7@fake.com", "Customer7" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "61", 0, "969f570f-9e5b-4fc3-aa52-dd35f7b4955a", "User", "Customer6@fake.com", true, true, null, "CUSTOMER6@FAKE.COM", "CUSTOMER6@FAKE.COM", "AQAAAAEAACcQAAAAEOpq6fG0dVPnyXyC+abT6s0Lv6k5FtZzCAHoN4HqHOPSYQ3c77Z2j3QBMsQYWI3WGg==", null, false, "d388d4ed-74b5-49db-b920-4118508f1d53", false, "Customer6@fake.com", "Customer6" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "82", 0, "f8953b4d-ee47-4452-8096-54ae2601d4bd", "Seller", "Seller8@fake.com", true, true, null, "SELLER8@FAKE.COM", "SELLER8@FAKE.COM", "AQAAAAEAACcQAAAAEANnlQn4yx7xijGasQ7mtaDDsUFimwtmdwHTyvRPfb/qmR4NrKTpEuQ6+41XmrPWMA==", null, false, "71c8e8c8-c7a2-4a70-9124-8c240a4af82b", false, "Seller8@fake.com", "Seller8", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "41", 0, "e555b699-1220-4eb4-8897-505327c1921e", "User", "Customer4@fake.com", true, true, null, "CUSTOMER4@FAKE.COM", "CUSTOMER4@FAKE.COM", "AQAAAAEAACcQAAAAEAKwauEVss+RcY7M/OM6XNeseJpPDinaSj7MtmbEejyY/6BRhxGHWeIZtnd+zL5ZGw==", null, false, "ca7a63e6-e012-4311-805d-3abdbad41de7", false, "Customer4@fake.com", "Customer4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "31", 0, "0581e598-5cc1-47ea-82f2-0fd59486ef1e", "User", "Customer3@fake.com", true, true, null, "CUSTOMER3@FAKE.COM", "CUSTOMER3@FAKE.COM", "AQAAAAEAACcQAAAAEFRLOQ9bCq+TRUJTgc1kuBg0eoBBkD7stKKkUx+g40E8lF9EHqKow58KVow6HZ8yaw==", null, false, "907cb385-3fb8-4b2d-a882-e947d64b0df0", false, "Customer3@fake.com", "Customer3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21", 0, "8eeaeffa-3da8-4306-8ec0-d65416ddd61d", "User", "Customer2@fake.com", true, true, null, "CUSTOMER2@FAKE.COM", "CUSTOMER2@FAKE.COM", "AQAAAAEAACcQAAAAEIZT0ktS1ziKoJh715FLa05Ay++LvUPs19PY/NdSvAInUiARD/8waEUfRGQDTw2JnQ==", null, false, "a3426eac-18b0-4482-a04c-3f47bb308e16", false, "Customer2@fake.com", "Customer2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "11", 0, "6c109a78-4530-4ea3-808d-4cd1b20bec42", "User", "Customer1@fake.com", true, true, null, "CUSTOMER1@FAKE.COM", "CUSTOMER1@FAKE.COM", "AQAAAAEAACcQAAAAEJFP2I7v9GlTV05LXUwPfr3ewLpaafdDCFmjMyAaaesrAqVk4xLWuXsGn3APeYeZCw==", null, false, "b1bf858b-cdb6-48d8-9058-c7b4f43e9674", false, "Customer1@fake.com", "Customer1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "102", 0, "08227276-b59d-4df4-b243-df575183f1f9", "Seller", "Seller10@fake.com", true, true, null, "SELLER10@FAKE.COM", "SELLER10@FAKE.COM", "AQAAAAEAACcQAAAAEGuwwNp76zj3FZs0dcv25rszVBh3EUUWt/OhsiCjCZdGAJ62SGu6VygXa5KOOxQ30Q==", null, false, "9f7f1e99-3ea8-49ae-9715-b0e221f4ba49", false, "Seller10@fake.com", "Seller10", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "92", 0, "b5faaabf-4cb3-49b5-94a8-552ddcf18362", "Seller", "Seller9@fake.com", true, true, null, "SELLER9@FAKE.COM", "SELLER9@FAKE.COM", "AQAAAAEAACcQAAAAEPfPUCy2NnxTm/7d8SLwbVUqbi9sgdP08pmTsHV+n4QQrVLdkgSK4o8DS8uNoQHSsg==", null, false, "2cae03fb-8d6c-42c5-9133-4ff75dea80b7", false, "Seller9@fake.com", "Seller9", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "51", 0, "07eacadd-2a00-44b2-9afb-c0a8bf45e620", "User", "Customer5@fake.com", true, true, null, "CUSTOMER5@FAKE.COM", "CUSTOMER5@FAKE.COM", "AQAAAAEAACcQAAAAEJsNX2MSUNXyJteg1TBbTsZME+395IbsoNwJSa09v9A7/fS9Y1XQSDoUrRV0FJys7g==", null, false, "8f9d5917-ee36-4f26-b6a2-5e7768c58704", false, "Customer5@fake.com", "Customer5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "72", 0, "2ef4534c-f870-494e-8e04-60a300b38af9", "Seller", "Seller7@fake.com", true, true, null, "SELLER7@FAKE.COM", "SELLER7@FAKE.COM", "AQAAAAEAACcQAAAAEPA4+hKK1h0uXXoNVSze0HvTtSi+fSVapApfMLnaeccs6L0i/Pxl8d87qT2TnwoJ9A==", null, false, "97a68d67-02bf-462d-bad5-0b0f235f54ff", false, "Seller7@fake.com", "Seller7", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "52", 0, "c404a70d-4d9f-4099-9160-e1cbbfc80a60", "Seller", "Seller5@fake.com", true, true, null, "SELLER5@FAKE.COM", "SELLER5@FAKE.COM", "AQAAAAEAACcQAAAAEGyUjflvO9G4h/CUTs5dwTngti665OsuDzg4y3U/0PwuwwWzwmWsVcr6T9cLspyhrA==", null, false, "e600f660-e36e-4bdf-8ac7-fb5544e143db", false, "Seller5@fake.com", "Seller5", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "42", 0, "cbd21639-6e8f-494d-9b70-6e9479e771b6", "Seller", "Seller4@fake.com", true, true, null, "SELLER4@FAKE.COM", "SELLER4@FAKE.COM", "AQAAAAEAACcQAAAAELOyajm/XiSbenG8ejPJEm9Wqr6QpQmOgKsNheg95Dciwn3abd2lmHZHYEpgEmdeDw==", null, false, "0751e242-40e4-40ad-8118-db2a69fe29ac", false, "Seller4@fake.com", "Seller4", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "32", 0, "d6fb8c64-4c5f-4752-aee5-d5d9cab688b3", "Seller", "Seller3@fake.com", true, true, null, "SELLER3@FAKE.COM", "SELLER3@FAKE.COM", "AQAAAAEAACcQAAAAEOSMPnn3/fAGE32qLdp8zHjt8A+Raw0z+AlGjK2dQ4S+pVzFdu1ROLsF0XJ3RM2ykA==", null, false, "821fd67c-3d92-42a6-8b98-61f6d537aac8", false, "Seller3@fake.com", "Seller3", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "22", 0, "d480d446-7b18-4eda-ac1c-cd60985a8ccb", "Seller", "Seller2@fake.com", true, true, null, "SELLER2@FAKE.COM", "SELLER2@FAKE.COM", "AQAAAAEAACcQAAAAEDyLia0G+wvWnRjXv+VVt4tYMz3hlQTTbCPZK6jQgcUqcuka1ID0PJLZKFd/n3C6OA==", null, false, "7da31d56-60dc-47df-92ff-96442e9bc447", false, "Seller2@fake.com", "Seller2", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "12", 0, "8df6aa1c-6567-4e09-a033-2fea1f8aca58", "Seller", "Seller1@fake.com", true, true, null, "SELLER1@FAKE.COM", "SELLER1@FAKE.COM", "AQAAAAEAACcQAAAAELigR9LgDokoNlVn7CTb16cHYd9USIWQgJfRX6QDeZjSTjtyfveLq4GmlBjbhCRVvw==", null, false, "1776e388-69a1-459f-b397-b0e559006587", false, "Seller1@fake.com", "Seller1", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "62", 0, "5c468c5b-e3cb-448c-9305-202988492037", "Seller", "Seller6@fake.com", true, true, null, "SELLER6@FAKE.COM", "SELLER6@FAKE.COM", "AQAAAAEAACcQAAAAEClmPfgWoOaX/4b634xro8NN1Y2hvD9uk8q+epMLF/eqjYP2c4j+VWSXd6WmzoFGeQ==", null, false, "5d2bdaa6-b676-423a-ab88-f2c59ddab8a1", false, "Seller6@fake.com", "Seller6", 0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 100, "Descripcion del producto10", "Producto10" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 90, "Descripcion del producto9", "Producto9" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 80, "Descripcion del producto8", "Producto8" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 70, "Descripcion del producto7", "Producto7" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 60, "Descripcion del producto6", "Producto6" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 50, "Descripcion del producto5", "Producto5" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 40, "Descripcion del producto4", "Producto4" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 30, "Descripcion del producto3", "Producto3" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 20, "Descripcion del producto2", "Producto2" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 10, "Descripcion del producto1", "Producto1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "11", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "41", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "51", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "61", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "71", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "81", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "91", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "101", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "31", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "21123111111", "a18be9c0Manager" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "22", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "32", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "42", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "52", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "62", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "72", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "82", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "12", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "21", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "102", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "92", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 75, new DateTime(2020, 7, 7, 11, 34, 37, 339, DateTimeKind.Local).AddTicks(7141), 10.0, new DateTime(2020, 7, 8, 4, 34, 37, 339, DateTimeKind.Local).AddTicks(7844), 7.0, false, "72" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 35, new DateTime(2020, 7, 7, 11, 34, 37, 254, DateTimeKind.Local).AddTicks(2350), 6.0, new DateTime(2020, 7, 7, 11, 34, 37, 254, DateTimeKind.Local).AddTicks(2523), 3.0, false, "32" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 55, new DateTime(2020, 7, 7, 11, 34, 37, 296, DateTimeKind.Local).AddTicks(9298), 8.0, new DateTime(2020, 7, 7, 11, 34, 37, 296, DateTimeKind.Local).AddTicks(9422), 5.0, false, "52" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 95, new DateTime(2020, 7, 7, 11, 34, 37, 388, DateTimeKind.Local).AddTicks(5799), 12.0, new DateTime(2020, 7, 8, 6, 34, 37, 388, DateTimeKind.Local).AddTicks(6279), 9.0, false, "92" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 15, new DateTime(2020, 7, 7, 16, 34, 37, 204, DateTimeKind.Local).AddTicks(162), 1.0, new DateTime(2020, 7, 7, 22, 34, 37, 212, DateTimeKind.Local).AddTicks(7981), 1.0, false, "12" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 34, "NotiRole", "Customer3 wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "31" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 64, "NotiRole", "Customer6 wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "61" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 94, "NotiRole", "Customer9 wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "91" });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 80003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11.0, 10, "82", 9 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 8003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11.0, 80, "82", 9 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 7003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11.0, 70, "72", 8 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 10003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12.0, 100, "102", 11 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 6003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10.0, 60, "62", 7 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 5003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10.0, 50, "52", 6 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 4003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9.0, 40, "42", 5 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 3003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9.0, 30, "32", 4 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 2003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8.0, 20, "22", 3 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 1003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8.0, 10, "12", 2 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 9003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12.0, 90, "92", 10 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 16, 15, null, 10, 1 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 100006, 15, null, 20, 1 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 36, 35, null, 30, 2 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 300006, 35, null, 40, 2 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 56, 55, null, 50, 3 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 500006, 55, null, 60, 3 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 76, 75, null, 70, 4 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 700006, 75, null, 80, 4 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 96, 95, null, 90, 5 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 900006, 95, null, 100, 5 });

            migrationBuilder.InsertData(
                table: "AuctionUser",
                columns: new[] { "Id", "AuctionId", "LastPriceOffered", "UserId" },
                values: new object[] { 30000007, 35, 4.0, "41" });

            migrationBuilder.InsertData(
                table: "AuctionUser",
                columns: new[] { "Id", "AuctionId", "LastPriceOffered", "UserId" },
                values: new object[] { 37, 35, 6.0, "31" });

            migrationBuilder.InsertData(
                table: "AuctionUser",
                columns: new[] { "Id", "AuctionId", "LastPriceOffered", "UserId" },
                values: new object[] { 77, 75, 10.0, "71" });

            migrationBuilder.InsertData(
                table: "AuctionUser",
                columns: new[] { "Id", "AuctionId", "LastPriceOffered", "UserId" },
                values: new object[] { 97, 95, 12.0, "91" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuctionHeader_SellerId",
                table: "AuctionHeader",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionProduct_AuctionId",
                table: "AuctionProduct",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionProduct_NotiAuctionId",
                table: "AuctionProduct",
                column: "NotiAuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionProduct_ProductId",
                table: "AuctionProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionUser_AuctionId",
                table: "AuctionUser",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionUser_UserId",
                table: "AuctionUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_AuctionHeaderID",
                table: "Notification",
                column: "AuctionHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_OrderHeaderID",
                table: "Notification",
                column: "OrderHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserID",
                table: "Notification",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_NotiBuyId",
                table: "OrderDetails",
                column: "NotiBuyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_NotiSellId",
                table: "OrderDetails",
                column: "NotiSellId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_UserId",
                table: "OrderHeader",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_ProductId",
                table: "ProductSale",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_SellerId",
                table: "ProductSale",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuctionProduct");

            migrationBuilder.DropTable(
                name: "AuctionUser");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProductSale");

            migrationBuilder.DropTable(
                name: "AuctionHeader");

            migrationBuilder.DropTable(
                name: "OrderHeader");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
