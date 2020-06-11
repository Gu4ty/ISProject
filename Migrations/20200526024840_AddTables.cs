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
                    Date = table.Column<DateTime>(nullable: false)
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
                values: new object[] { "a18be9c0Seller", "a142dddc-2757-46dc-9af9-0ab30fca3e31", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Manager", "22ad42d2-908f-43b2-9601-499a1c1638e4", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Customer", "2e08f6a4-5067-48db-b46d-ba630c8e582e", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21123111111", 0, "67e9299f-587f-4eb1-9950-0bd309e29204", "User", "admin@fake.com", true, true, null, "ADMIN@FAKE.COM", "ADMIN@FAKE.COM", "AQAAAAEAACcQAAAAEJqdj/lDsqHa07CI6DeJtEskhGW4kNy6NIzfhr+2NqQon0fFS+BUATg7ujaJdKHNgw==", null, false, "415ad44b-592f-4be0-b6a1-abc648fa52c5", false, "admin@fake.com", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "101", 0, "1f667eaf-8953-4e66-ad6b-6b58cfb1562b", "User", "Customer10@fake.com", true, true, null, "CUSTOMER10@FAKE.COM", "CUSTOMER10@FAKE.COM", "AQAAAAEAACcQAAAAEFr8/DF/Ost/Khd7++1INphk2/eJgjIMkI/zwjj6O1rGgeVHeWExUcduuCP2XNhj8g==", null, false, "de240db0-3a06-4e58-8e32-c824ec9d65dc", false, "Customer10@fake.com", "Customer10" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "91", 0, "a244f9bf-e658-45f7-a8ef-6d47438a95f7", "User", "Customer9@fake.com", true, true, null, "CUSTOMER9@FAKE.COM", "CUSTOMER9@FAKE.COM", "AQAAAAEAACcQAAAAEPi2N1OF5nD7sKbJ7z6mkjO0TMvl61A3N4uhcdTn9WrkQNQ3VDn30z2IMmodRcDn9g==", null, false, "ac65e38b-d94c-419d-bb8a-fca10741b4c8", false, "Customer9@fake.com", "Customer9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "81", 0, "69f4755a-6162-43de-96bc-9a35ef4bf701", "User", "Customer8@fake.com", true, true, null, "CUSTOMER8@FAKE.COM", "CUSTOMER8@FAKE.COM", "AQAAAAEAACcQAAAAEOcBdaphB6NwstSVv6w7NHjdsNaINljT7yP6Z4yi7f09boYCaj8fKNc+SHhWdUvQXA==", null, false, "69218544-5771-481e-bb39-8c0fe6ffaa69", false, "Customer8@fake.com", "Customer8" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "71", 0, "e25df0a4-e2d8-4f56-a4f6-62809fb8965a", "User", "Customer7@fake.com", true, true, null, "CUSTOMER7@FAKE.COM", "CUSTOMER7@FAKE.COM", "AQAAAAEAACcQAAAAEDAUCKcRipuFg0sFOsgK8VnuTyDbodH9bI6MTV9wUy85HZa3ADFhlvSMrDnFqSMcrA==", null, false, "49196378-9a7a-4ae8-8211-09c930b2de93", false, "Customer7@fake.com", "Customer7" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "61", 0, "340d3da6-3225-4982-bcf9-ad5f3cadc96c", "User", "Customer6@fake.com", true, true, null, "CUSTOMER6@FAKE.COM", "CUSTOMER6@FAKE.COM", "AQAAAAEAACcQAAAAEPuiRvqSoh7TvRPSKwtonpZykAYNnt0S1NMnKhYEaULTAVcW8hSxv+2UuxIpwOCEUA==", null, false, "145069f9-3729-44c7-b7b4-ec7c405ff112", false, "Customer6@fake.com", "Customer6" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "82", 0, "0d3bd040-5d5f-416d-bcce-31cdd223624b", "Seller", "Seller8@fake.com", true, true, null, "SELLER8@FAKE.COM", "SELLER8@FAKE.COM", "AQAAAAEAACcQAAAAENIozJm++gSzMkGI8hanrh/P0MMzZNqbmFRtSUTt5IrgO4Tm0DbJcdtxFvk+8149sA==", null, false, "b218fbc3-0411-4760-a498-d1841d07a83c", false, "Seller8@fake.com", "Seller8", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "41", 0, "0b1a7f0f-0568-4ba2-82ae-5566cb9735dc", "User", "Customer4@fake.com", true, true, null, "CUSTOMER4@FAKE.COM", "CUSTOMER4@FAKE.COM", "AQAAAAEAACcQAAAAEOeBabfkYaJNq+ONdSA4uvJ/q6o9F4ZWTYjQD99A4dDvLc/mMdkcRrm/eBX04uMrgw==", null, false, "c078b1ac-80aa-452b-be9c-497669007318", false, "Customer4@fake.com", "Customer4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "31", 0, "3d5ab4b0-db1f-4186-b487-7b608b37859f", "User", "Customer3@fake.com", true, true, null, "CUSTOMER3@FAKE.COM", "CUSTOMER3@FAKE.COM", "AQAAAAEAACcQAAAAEBOiGeiYL45I/DG5jMj6qFLQJHgZbz4j9sSp7OOaLIaK2nBUtXT0s6wa6NMHai9x5g==", null, false, "670b52da-290b-4c25-ba90-417f3ddb3c32", false, "Customer3@fake.com", "Customer3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21", 0, "44a126a0-6281-44ef-8202-01e2d2a7570b", "User", "Customer2@fake.com", true, true, null, "CUSTOMER2@FAKE.COM", "CUSTOMER2@FAKE.COM", "AQAAAAEAACcQAAAAEMXiH/qLM/nABzVvIFD5F3KdW1/d8fSZjGgszzIV99SDmj1+BYxZ0NsNpOHkdtxLsg==", null, false, "9802b5e0-ee34-4e7f-8e94-7db3e013f098", false, "Customer2@fake.com", "Customer2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "11", 0, "6e6d2078-b3f9-4c2b-8d6e-8e0304505d1f", "User", "Customer1@fake.com", true, true, null, "CUSTOMER1@FAKE.COM", "CUSTOMER1@FAKE.COM", "AQAAAAEAACcQAAAAEESgSWgbYJ3wLiXw0lvYPGupln5zJzajRxuxXUwpRJqaI7VJhpqPM3KZPzT8QneGKA==", null, false, "b8e6001e-48e6-4dc4-8495-9d7d8f03a532", false, "Customer1@fake.com", "Customer1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "102", 0, "3d8bf1f6-0afa-4e16-8669-76bacbbc3d79", "Seller", "Seller10@fake.com", true, true, null, "SELLER10@FAKE.COM", "SELLER10@FAKE.COM", "AQAAAAEAACcQAAAAEHbil99d8avvokdE18x9LBw9d06R4ezFdfvSEHPjVcE6o7sBd39HCwWQA6xTkT5ArQ==", null, false, "3e60550f-1a29-4706-ba0d-2a75a0561c34", false, "Seller10@fake.com", "Seller10", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "92", 0, "3c534fe8-053f-4a74-b6e1-3f123ab0a42a", "Seller", "Seller9@fake.com", true, true, null, "SELLER9@FAKE.COM", "SELLER9@FAKE.COM", "AQAAAAEAACcQAAAAEGo/MclLeMODrvBEfp/vtDlskJOYSqIfDVKo+fw1gJGJV3/NkFpy24rJ/VizBopKoQ==", null, false, "3bda75da-9b02-4517-b7d1-403e4d55c970", false, "Seller9@fake.com", "Seller9", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "51", 0, "6d85c4b3-5ee1-4ede-91a4-b1705eb1803e", "User", "Customer5@fake.com", true, true, null, "CUSTOMER5@FAKE.COM", "CUSTOMER5@FAKE.COM", "AQAAAAEAACcQAAAAEOds7MmyAqYSNB81QwqGfPFFfd7kmsuSEW4Djw25YLxqgiyvR/Z+Iq5KcO6FqBRizw==", null, false, "10726519-b4d2-49e5-a4d1-5bee8ab85bc9", false, "Customer5@fake.com", "Customer5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "72", 0, "e34c390f-bf41-48ef-b9ec-9c797e092aaa", "Seller", "Seller7@fake.com", true, true, null, "SELLER7@FAKE.COM", "SELLER7@FAKE.COM", "AQAAAAEAACcQAAAAEEHLiqh13by6YUayQQSOQTwOc8o0/PlJNd4R0N1AhcdtCDeuZQ/C4DEfxLoxn60OgQ==", null, false, "d83e090e-6163-4985-b9b0-f14ad4142e05", false, "Seller7@fake.com", "Seller7", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "52", 0, "be8a5d4a-dfb4-4799-90e1-c4524a099ef5", "Seller", "Seller5@fake.com", true, true, null, "SELLER5@FAKE.COM", "SELLER5@FAKE.COM", "AQAAAAEAACcQAAAAEIpoH4ECkkvnelVNI2gM0yY8QBHf7mHFICHcflg7G0F9+TV/FSouZmZdnCznmH+69w==", null, false, "6513ff31-1e16-49a2-86ce-45b432fb12fa", false, "Seller5@fake.com", "Seller5", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "42", 0, "66277470-5e2f-4579-a9d4-5cfd02925ea9", "Seller", "Seller4@fake.com", true, true, null, "SELLER4@FAKE.COM", "SELLER4@FAKE.COM", "AQAAAAEAACcQAAAAEPlE5AUsIivaoM9oj1FyHlzDWbydUDHPK/we3hwkYd/t36husOJClpPXymf18gygwQ==", null, false, "1385f2dd-8c6b-4421-92c0-0a7532bd0f65", false, "Seller4@fake.com", "Seller4", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "32", 0, "a281082f-3382-476a-af97-798ec069b6a6", "Seller", "Seller3@fake.com", true, true, null, "SELLER3@FAKE.COM", "SELLER3@FAKE.COM", "AQAAAAEAACcQAAAAEFNzjQwjM+f2KWij8cVSMW9fFGpsIhKE6J4TwVgr/AYh/NIjvA3uSfmdKu7VfJA1Qg==", null, false, "af51a61f-a05e-42b2-99de-9625c445a3c6", false, "Seller3@fake.com", "Seller3", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "22", 0, "14e338e4-d8d5-462e-b981-b415878218bc", "Seller", "Seller2@fake.com", true, true, null, "SELLER2@FAKE.COM", "SELLER2@FAKE.COM", "AQAAAAEAACcQAAAAEKhUF9LFEJY5FYFvn0sbZ05qYTHjF/bS3z56p7Q12baUoe4AkFdPNdir1Ta6U0PGhw==", null, false, "a54427f5-3d21-40c8-82ce-f2009f79ff63", false, "Seller2@fake.com", "Seller2", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "12", 0, "5281fbc2-92c8-4bdd-b5a6-462d5c1a2265", "Seller", "Seller1@fake.com", true, true, null, "SELLER1@FAKE.COM", "SELLER1@FAKE.COM", "AQAAAAEAACcQAAAAEN9ZvyTLQPbpzJkKQiwVzMls2aMie6ZkT3s2vdS1h2Cs8M7dHe40jpRWevPvHPxbeg==", null, false, "bafd3938-c87c-492c-a838-901abe34829f", false, "Seller1@fake.com", "Seller1", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "62", 0, "1f4e0536-3981-41d9-9858-b735e4b644ea", "Seller", "Seller6@fake.com", true, true, null, "SELLER6@FAKE.COM", "SELLER6@FAKE.COM", "AQAAAAEAACcQAAAAEExw7EVATYHQgd5c+32U7QrvT4ch9jIhILGyBBtVrUs0xiLgNXvloQBHjQlO/DGTIQ==", null, false, "eecb7ba5-de02-4156-8d62-a4668b00692c", false, "Seller6@fake.com", "Seller6", 0 });

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
                values: new object[] { 75, new DateTime(2020, 5, 25, 22, 48, 38, 512, DateTimeKind.Local).AddTicks(2445), 10.0, new DateTime(2020, 5, 26, 15, 48, 38, 512, DateTimeKind.Local).AddTicks(3149), 7.0, false, "72" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 35, new DateTime(2020, 5, 25, 22, 48, 38, 409, DateTimeKind.Local).AddTicks(1915), 6.0, new DateTime(2020, 5, 25, 22, 48, 38, 409, DateTimeKind.Local).AddTicks(2073), 3.0, false, "32" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 55, new DateTime(2020, 5, 25, 22, 48, 38, 458, DateTimeKind.Local).AddTicks(3278), 8.0, new DateTime(2020, 5, 25, 22, 48, 38, 458, DateTimeKind.Local).AddTicks(3373), 5.0, false, "52" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 95, new DateTime(2020, 5, 25, 22, 48, 38, 568, DateTimeKind.Local).AddTicks(8194), 12.0, new DateTime(2020, 5, 26, 17, 48, 38, 568, DateTimeKind.Local).AddTicks(9235), 9.0, false, "92" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 15, new DateTime(2020, 5, 26, 3, 48, 38, 345, DateTimeKind.Local).AddTicks(9472), 1.0, new DateTime(2020, 5, 26, 9, 48, 38, 356, DateTimeKind.Local).AddTicks(1629), 1.0, false, "12" });

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
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 80003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.0, 10, "82", 9 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 8003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.0, 80, "82", 9 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 7003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.0, 70, "72", 8 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 10003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, 100, "102", 11 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 6003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, 60, "62", 7 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 5003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, 50, "52", 6 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 4003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0, 40, "42", 5 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 3003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0, 30, "32", 4 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 2003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0, 20, "22", 3 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 1003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0, 10, "12", 2 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 9003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, 90, "92", 10 });

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
