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
                    OrderHeaderID = table.Column<int>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    OrderDetailsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
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
                    Price = table.Column<double>(nullable: false),
                    NotiBuyId = table.Column<int>(nullable: true)
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
                values: new object[] { "a18be9c0Seller", "b0c75242-5e76-46f9-af97-900f8946ec81", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Manager", "e09bc067-3161-444e-b9c4-9bf7a23a6bcc", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Customer", "b8a3897a-60cc-4b60-a185-f0635c884c9f", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21123111111", 0, "0edb3f9b-932b-4ec1-87dc-9b3ab6282264", "User", "admin@fake.com", true, true, null, "ADMIN@FAKE.COM", "ADMIN@FAKE.COM", "AQAAAAEAACcQAAAAEH8uOl4ZS4rtq4x6bAmF671CuomAiEr1DqU2uuibu7V+/sIcXfBRzsQsU+z+xJvLfA==", null, false, "71b66e98-e4f0-4d1a-8789-ce71e68e1cdd", false, "admin@fake.com", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "101", 0, "277e84b7-a159-4456-84f7-c07b8299427f", "User", "Customer10@fake.com", true, true, null, "CUSTOMER10@FAKE.COM", "CUSTOMER10@FAKE.COM", "AQAAAAEAACcQAAAAEKgctBDRvNTgGHsdayJMoePShI/JXfonhFQfedLaae8x/RBDHtlzfmaIQUFF1XuFyQ==", null, false, "2e66fe49-f5b4-4301-bec8-97f4d3753634", false, "Customer10@fake.com", "Customer10" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "91", 0, "043f9a4a-04bb-4ebb-a85d-737bb336b0cb", "User", "Customer9@fake.com", true, true, null, "CUSTOMER9@FAKE.COM", "CUSTOMER9@FAKE.COM", "AQAAAAEAACcQAAAAEHm5JbM4yrtVpV1o4wpMmgadfb+kE36/1YDtszo6yqJBeSk587drrcCewDneKQMiVw==", null, false, "62fa42be-a684-4d20-a2e4-b4bfbe083382", false, "Customer9@fake.com", "Customer9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "81", 0, "eaf57886-b8f4-4322-89ff-8eadec77e1ab", "User", "Customer8@fake.com", true, true, null, "CUSTOMER8@FAKE.COM", "CUSTOMER8@FAKE.COM", "AQAAAAEAACcQAAAAENQLEHYj7Myh0ojwsKB22LPLFs2VJy1KcSv13mXnBNwbJcpEFeOCk3eQ+7uZlkBVzw==", null, false, "6f03656b-7b7e-4955-ad94-082ab7e8d1c9", false, "Customer8@fake.com", "Customer8" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "71", 0, "21648050-6f9d-46fa-9a8c-6aaf4debe85a", "User", "Customer7@fake.com", true, true, null, "CUSTOMER7@FAKE.COM", "CUSTOMER7@FAKE.COM", "AQAAAAEAACcQAAAAENrDMEP2yzrKWHHbHwyyeYN1jt1KJmkidj+IsV4zZljOhd2UJ0V6X20ytYwBf/PmKA==", null, false, "a30a8111-127f-4481-af2d-63d7fa7bfb4e", false, "Customer7@fake.com", "Customer7" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "61", 0, "252bbdad-f3b1-4915-a975-c4b37ccfeb7f", "User", "Customer6@fake.com", true, true, null, "CUSTOMER6@FAKE.COM", "CUSTOMER6@FAKE.COM", "AQAAAAEAACcQAAAAECb5N8bKknf9LYe7vqKGHHntz7ZIcwFR5t4FjbmTm57aOLMvAcFFlwY8ZtaSMUgtIw==", null, false, "0f427875-1234-4bf9-8f24-168f8547c2e1", false, "Customer6@fake.com", "Customer6" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "82", 0, "5c9f2936-acc8-4586-8e45-9fe2d1e364b7", "Seller", "Seller8@fake.com", true, true, null, "SELLER8@FAKE.COM", "SELLER8@FAKE.COM", "AQAAAAEAACcQAAAAEPu8NfWW3ABXgao69baFhQRq5N8+APnBuFCtvfK2QSTwKyuIkXGjeBsW7MmyfgTQWA==", null, false, "b6d9ae04-9bdf-4c5d-89e3-cae00415b757", false, "Seller8@fake.com", "Seller8", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "41", 0, "73fc6a78-19eb-4508-b5ae-609774afa60f", "User", "Customer4@fake.com", true, true, null, "CUSTOMER4@FAKE.COM", "CUSTOMER4@FAKE.COM", "AQAAAAEAACcQAAAAEKrIrecsP3HVpUp9sUqZ/qopVaqKO5kCbBeEn65vd3s0HdASoeuSjsxI7OwdPIod5g==", null, false, "c3fc1e43-7c9f-4bc8-a026-8e66884306e0", false, "Customer4@fake.com", "Customer4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "31", 0, "688d9df5-85a8-4391-9e11-f81a9216e261", "User", "Customer3@fake.com", true, true, null, "CUSTOMER3@FAKE.COM", "CUSTOMER3@FAKE.COM", "AQAAAAEAACcQAAAAEH1MqjtmYN3El72E+5Cj3NUN10R57BtMuxcYfPxHpFKB9hDeizmhVq7k/Wg/7vN1/Q==", null, false, "c8e21719-b666-4939-9581-751dc0aebd0f", false, "Customer3@fake.com", "Customer3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21", 0, "1dd0f7e4-a1d0-418f-af3f-55f1260c4176", "User", "Customer2@fake.com", true, true, null, "CUSTOMER2@FAKE.COM", "CUSTOMER2@FAKE.COM", "AQAAAAEAACcQAAAAELv5jy6v8SlVcSCSJkUHZ1LovvMJJ/sNol4vNY0WnNTKB4kwpJ1gJQDVoDvYDWP2pg==", null, false, "3535927e-9aa1-475d-9a8e-c271eb9a5991", false, "Customer2@fake.com", "Customer2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "11", 0, "f754484b-48ea-4524-bf3c-19825f48ffc9", "User", "Customer1@fake.com", true, true, null, "CUSTOMER1@FAKE.COM", "CUSTOMER1@FAKE.COM", "AQAAAAEAACcQAAAAEBXwiFL42gVLcsfe+BozNYoWHQGMpuHAR3O43oRDZoL7mZkDrxywaRCWKPflh4asmA==", null, false, "b539febd-b9a4-42bb-8cde-a2c9207d7e07", false, "Customer1@fake.com", "Customer1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "102", 0, "0afb4a49-2798-4fcd-b0cc-c0d850384fad", "Seller", "Seller10@fake.com", true, true, null, "SELLER10@FAKE.COM", "SELLER10@FAKE.COM", "AQAAAAEAACcQAAAAEAMDu/5/wdo583KTSH7EAB9US0gNtGoHrUf/BzZOPKvjNEWC77Ob3MSleXK8BxArUw==", null, false, "ac4481c1-feb9-4971-b633-c13c30de88ad", false, "Seller10@fake.com", "Seller10", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "92", 0, "a3c45067-6ebb-4ae2-90bb-75207f9988c8", "Seller", "Seller9@fake.com", true, true, null, "SELLER9@FAKE.COM", "SELLER9@FAKE.COM", "AQAAAAEAACcQAAAAEBYlceTWhNBiS6tdeLBMcZ+YHBoSdqNNuYjtbeZuWZ8NliPlT1AgMYdRO1HR3PzW+A==", null, false, "b6c8b2b3-d7bb-40eb-81dc-f0dfb759bb5b", false, "Seller9@fake.com", "Seller9", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "51", 0, "e78a431b-1999-4338-ae83-e0984d88506c", "User", "Customer5@fake.com", true, true, null, "CUSTOMER5@FAKE.COM", "CUSTOMER5@FAKE.COM", "AQAAAAEAACcQAAAAEG9oH2VbhGn11fs9UyYlfzH5SFM/1tSSLo/fMdqWv6xIreHT1yWkopUoCTfah4qSpA==", null, false, "fd5c4d34-f607-471c-82b8-9a280d79923e", false, "Customer5@fake.com", "Customer5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "72", 0, "f8bed465-7696-40d8-a94c-5290c82a250e", "Seller", "Seller7@fake.com", true, true, null, "SELLER7@FAKE.COM", "SELLER7@FAKE.COM", "AQAAAAEAACcQAAAAEOaiC+5xBOI6PJb/m2+BcqRUYi3t0fy14f2F5A4qe0VdvLoCCdxzQwNH2uvtyUMKDQ==", null, false, "d4921fed-8bd9-4524-b695-9a1def7914a7", false, "Seller7@fake.com", "Seller7", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "52", 0, "798ec7bc-5e5e-461f-b752-eaffc0b4134a", "Seller", "Seller5@fake.com", true, true, null, "SELLER5@FAKE.COM", "SELLER5@FAKE.COM", "AQAAAAEAACcQAAAAEBD/8npTF2IFqP1SJHRrhS9RwwmAcPdJqA6sQkS6KHa1n4rh1INMNiuyJylkhnbDTA==", null, false, "a65c0ada-077f-4b3c-b315-81e469877db8", false, "Seller5@fake.com", "Seller5", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "42", 0, "f31fec12-d1ec-4244-8d80-c2c17e569c0d", "Seller", "Seller4@fake.com", true, true, null, "SELLER4@FAKE.COM", "SELLER4@FAKE.COM", "AQAAAAEAACcQAAAAEOnuUsusbBdoX79ZDYVBfBfqz6gc4Vw4jXRo+U8LJwGU/PmNyuPXYTvKCliwNT4N0g==", null, false, "9487ea5a-306a-4129-b89b-d4edc5a5be2b", false, "Seller4@fake.com", "Seller4", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "32", 0, "5d09f9ec-37d3-4bad-ab17-c50a0da86c58", "Seller", "Seller3@fake.com", true, true, null, "SELLER3@FAKE.COM", "SELLER3@FAKE.COM", "AQAAAAEAACcQAAAAEBjXq+5G5ssmn+jKZDZy8F649GJdlmDTg8RCXM14K1fm4em5abCCgRc5M3yyPRpN7g==", null, false, "35e55de2-ccc9-4b5c-b1d0-659bcb4e5368", false, "Seller3@fake.com", "Seller3", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "22", 0, "006517df-4b6f-4fe9-aad9-96390262975b", "Seller", "Seller2@fake.com", true, true, null, "SELLER2@FAKE.COM", "SELLER2@FAKE.COM", "AQAAAAEAACcQAAAAEDhjeiMlt8vOHqWRbU1JUqfwTBrL7xIA6OcjolGSQbeBZfk0Ig/yR15j2PeztlTKRg==", null, false, "2783476a-4214-4724-b303-e2b9d9e31251", false, "Seller2@fake.com", "Seller2", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "12", 0, "765f4617-41c1-476f-870e-dbdbcebb7442", "Seller", "Seller1@fake.com", true, true, null, "SELLER1@FAKE.COM", "SELLER1@FAKE.COM", "AQAAAAEAACcQAAAAEODDQLnLvDmNFa5sGq3qR6LkLwBZyTg/VxMx7uAa3kWcSP8hKp/cdoVwTYlF4sZTtQ==", null, false, "5b522cca-f516-43e1-9cc9-5cec71ac056e", false, "Seller1@fake.com", "Seller1", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "62", 0, "3de51c9d-6ffe-436b-a7b3-825ef4566433", "Seller", "Seller6@fake.com", true, true, null, "SELLER6@FAKE.COM", "SELLER6@FAKE.COM", "AQAAAAEAACcQAAAAEJZ/yO1GZu1qvYSisV+DtbpkndHpX5A1arY8VQAJpYA8YoGSGlBxrVOyMxmbgeItIg==", null, false, "a99e7d2b-70db-496c-900b-a2d467665b31", false, "Seller6@fake.com", "Seller6", 0 });

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
                values: new object[] { "41", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "82", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "72", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "62", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "52", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "42", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "32", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "22", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "12", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "21123111111", "a18be9c0Manager" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "101", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "91", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "81", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "71", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "61", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "51", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "102", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "31", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "21", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "11", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "92", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 94, "NotiRole", "Customer9 wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "91" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 64, "NotiRole", "Customer6 wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "61" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 34, "NotiRole", "Customer3 wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "31" });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 2003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0, 20, "22", 3 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 3003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0, 30, "32", 4 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 4003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0, 40, "42", 5 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 5003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, 50, "52", 6 });

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
                values: new object[] { 9003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, 90, "92", 10 });

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
                values: new object[] { 1003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0, 10, "12", 2 });

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
                name: "IX_Notification_OrderHeaderID",
                table: "Notification",
                column: "OrderHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserID",
                table: "Notification",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_OrderDetailsID",
                table: "Notification",
                column: "OrderDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_NotiBuyId",
                table: "OrderDetails",
                column: "NotiBuyId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_OrderDetails_OrderDetailsID",
                table: "Notification",
                column: "OrderDetailsID",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_UserID",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_UserId",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_AspNetUsers_SellerId",
                table: "ProductSale");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_OrderHeader_OrderHeaderID",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderHeader_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_OrderDetails_OrderDetailsID",
                table: "Notification");

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
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrderHeader");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProductSale");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
