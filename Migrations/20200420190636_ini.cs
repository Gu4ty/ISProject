using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISProject.Migrations
{
    public partial class ini : Migration
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
                values: new object[] { "a18be9c0Seller", "c2a3f8cc-c011-4bc6-8c99-369adc46f26a", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Manager", "d0866c70-5e95-41cd-aeaf-c6bfff761314", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Customer", "dde60f64-3ab9-4286-b17a-8db409223396", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21123111111", 0, "f555d0d8-a9a5-4f46-aaeb-508cd87b334c", "User", "admin@fake.com", true, true, null, "ADMIN@FAKE.COM", "ADMIN@FAKE.COM", "AQAAAAEAACcQAAAAEEy6FG05YXoUz3OOMR9oiyL+k4OKCpP6/unLpbl3Xd11zVODjw/5HeLvTyMtAf0SyQ==", null, false, "f020659c-5b42-4ca4-834b-16fedd4c08ca", false, "admin@fake.com", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "101", 0, "8954e210-41f0-459b-9e13-c82db611fa56", "User", "Customer10@fake.com", true, true, null, "CUSTOMER10@FAKE.COM", "CUSTOMER10@FAKE.COM", "AQAAAAEAACcQAAAAELo385F+bqcXgc85+FrVFvbw4rXx8dUII8zyw6VAI3Uyh7i+qYweSvfvQtlabQd7yg==", null, false, "239058b2-2059-4e4b-a9c5-db45cf7fcbc7", false, "Customer10@fake.com", "Customer10" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "91", 0, "86498988-0abf-4188-bf66-c3be528c0ac9", "User", "Customer9@fake.com", true, true, null, "CUSTOMER9@FAKE.COM", "CUSTOMER9@FAKE.COM", "AQAAAAEAACcQAAAAEIvZ1ylgoSyMhHfNDFUvsd343UVHJ7f2QwJsGALu1/lKnH2iMuTqodf20XSyeuDUmA==", null, false, "9812f688-7202-4a84-948a-5b4d8ddd71a9", false, "Customer9@fake.com", "Customer9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "81", 0, "a2f30537-29e4-4936-aeb2-14faa2465a30", "User", "Customer8@fake.com", true, true, null, "CUSTOMER8@FAKE.COM", "CUSTOMER8@FAKE.COM", "AQAAAAEAACcQAAAAEJ+Hz1njM6yIuHlne8I/1AXZ7zSHCVU9XWEA0lC0YJmARb/GGAw6qnMB4V/uVeZM1g==", null, false, "78afdf35-c6ef-4c40-969b-45cdada33866", false, "Customer8@fake.com", "Customer8" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "71", 0, "e2185b97-7d94-41ad-8375-792c2ae31a06", "User", "Customer7@fake.com", true, true, null, "CUSTOMER7@FAKE.COM", "CUSTOMER7@FAKE.COM", "AQAAAAEAACcQAAAAEBeTF41uChwZoZIXRKyNf4QO21b37orwNJfCtx5QpbjmigF5E97Hwu1bKBAlUlxaYQ==", null, false, "d897a84c-bd04-42dc-b89c-a971fb0af0bd", false, "Customer7@fake.com", "Customer7" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "61", 0, "0a30fa42-10a5-4fe1-acf4-50b91f7f03cd", "User", "Customer6@fake.com", true, true, null, "CUSTOMER6@FAKE.COM", "CUSTOMER6@FAKE.COM", "AQAAAAEAACcQAAAAEISkF3uSwyBmUui1TYxJZ2KCaua4jCYa3rX54FAiCEzPv/CLjzDeKA4XbOatV0IGqA==", null, false, "63262c94-c5bc-421b-bfdd-c55846804ebd", false, "Customer6@fake.com", "Customer6" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "82", 0, "83ae9d47-4f19-4cae-8a80-027d17ee447a", "Seller", "Seller8@fake.com", true, true, null, "SELLER8@FAKE.COM", "SELLER8@FAKE.COM", "AQAAAAEAACcQAAAAEJ41lU7y05qEmRBRXYnrgrTkB/kDj8S0dawdLzpN6T1QUTzV5aF0b1KcT3Tp5xlvEg==", null, false, "8b4d543d-eff7-4f08-b362-2cacfd10b437", false, "Seller8@fake.com", "Seller8", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "41", 0, "ef3d5748-52e1-4011-bfc7-13c8a7e4eb0e", "User", "Customer4@fake.com", true, true, null, "CUSTOMER4@FAKE.COM", "CUSTOMER4@FAKE.COM", "AQAAAAEAACcQAAAAEGHF91rk/HF6sRmJRqKUhbt1+PnwCArwZqFiUtxwnbMtFiJ4L6a9k7D7OG76cZsqZA==", null, false, "e22850a8-13e8-408e-ba3f-0f635c6fe2ad", false, "Customer4@fake.com", "Customer4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "31", 0, "776b777a-64ef-47ac-a4b2-4a24f59a63cd", "User", "Customer3@fake.com", true, true, null, "CUSTOMER3@FAKE.COM", "CUSTOMER3@FAKE.COM", "AQAAAAEAACcQAAAAECLjlVFyDGjehFFgLMDVeyzyOVW3SfIZuHE8ruNkgK+eBAwjGhYZJ70aHbyo3zRfkQ==", null, false, "e0de2f9c-fb83-48ee-95b9-f317c6324cd3", false, "Customer3@fake.com", "Customer3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21", 0, "6fdd98a8-2208-4ba2-ac74-e27142b30b26", "User", "Customer2@fake.com", true, true, null, "CUSTOMER2@FAKE.COM", "CUSTOMER2@FAKE.COM", "AQAAAAEAACcQAAAAECehSMvhzWQxww+2Bb6F4t9ttA9K2izvzS2Ww9bwjgE1fxqQurJvgVXu5dc6RYSs4g==", null, false, "f9e134b4-98cb-4c1d-bba3-9ba1f8450a0a", false, "Customer2@fake.com", "Customer2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "11", 0, "73f199ab-4e4a-469e-ab7d-0c344968120c", "User", "Customer1@fake.com", true, true, null, "CUSTOMER1@FAKE.COM", "CUSTOMER1@FAKE.COM", "AQAAAAEAACcQAAAAEBlWPTGS+1k5eXYhseecTQhifTQkKFov38ziWmhVpQk9KakeFMkJavqT8tIHTZvxOA==", null, false, "41e2a470-23d8-452a-aed9-3f1f36275268", false, "Customer1@fake.com", "Customer1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "102", 0, "5a150b50-fe38-4e51-9f3c-6b490a4c4768", "Seller", "Seller10@fake.com", true, true, null, "SELLER10@FAKE.COM", "SELLER10@FAKE.COM", "AQAAAAEAACcQAAAAEBT2Uq6tA/cVBrinKcPu83jU+649KvMpTonJ5U+6S5Nt49qDHdN2m5ZUgbyZZ7g1Rw==", null, false, "b70aeb16-18c2-419d-91c5-5a3555142aef", false, "Seller10@fake.com", "Seller10", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "92", 0, "b3c3b1d5-ec8b-4584-82fa-8e7135713598", "Seller", "Seller9@fake.com", true, true, null, "SELLER9@FAKE.COM", "SELLER9@FAKE.COM", "AQAAAAEAACcQAAAAEOpk4BpWoOslEQmjYR1aP8YWzX8rsmXDs6ASYTkp+rDNTgdeTSlzmTLYzeKu6AlTlA==", null, false, "a7666612-7635-46d8-b995-1d523680d829", false, "Seller9@fake.com", "Seller9", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "51", 0, "0ca9a37a-ae72-489a-9333-8eea1b40a661", "User", "Customer5@fake.com", true, true, null, "CUSTOMER5@FAKE.COM", "CUSTOMER5@FAKE.COM", "AQAAAAEAACcQAAAAEGDeZXrYNRQTCff7HS5UKR/2Bt2qi7W5343qlhPP0reIH+tLTkOwvv1sPdrpEWytmA==", null, false, "34418077-1aa3-4c71-a95a-720a1357d9ab", false, "Customer5@fake.com", "Customer5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "72", 0, "2d4b392f-e22a-486c-ad27-201a191541c3", "Seller", "Seller7@fake.com", true, true, null, "SELLER7@FAKE.COM", "SELLER7@FAKE.COM", "AQAAAAEAACcQAAAAEJmSjevp8aIhOmUKRN1NMvNb/1qsQskQeoTRR/HWeVfKOTx/HCntd0yDyze+1m6dBA==", null, false, "d4c721ea-265b-4eb8-9e35-0e32d3b5de79", false, "Seller7@fake.com", "Seller7", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "52", 0, "d86ce3c3-786e-48bf-a531-4261d58322a4", "Seller", "Seller5@fake.com", true, true, null, "SELLER5@FAKE.COM", "SELLER5@FAKE.COM", "AQAAAAEAACcQAAAAEFwfX/gyfAh1kRcylc6v8BhVdtNvd3KmtPh3wC4IrQRuYS+bFaTNtM3JHkWrQOpm6w==", null, false, "c90e2deb-15a2-4e12-8163-f7f15c68971f", false, "Seller5@fake.com", "Seller5", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "42", 0, "19ff18b4-a48c-45ae-a1e1-aa0568a4c245", "Seller", "Seller4@fake.com", true, true, null, "SELLER4@FAKE.COM", "SELLER4@FAKE.COM", "AQAAAAEAACcQAAAAECNklgU7cKzfAqNEiqqm8u8zEEoe6z+HNdFv22j3i1e9t7Qhq2GAv8PqYjgYZLvyLg==", null, false, "a08e0ec9-3999-4982-86d2-e08272bf4521", false, "Seller4@fake.com", "Seller4", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "32", 0, "2c799348-564b-48c7-9209-9ddcefa57f56", "Seller", "Seller3@fake.com", true, true, null, "SELLER3@FAKE.COM", "SELLER3@FAKE.COM", "AQAAAAEAACcQAAAAEFX/b6z5rBawzGhHfz9h0MxY1SoSBt+G4VVhAT8ALOk8/IGsnok982n4p+oWomJuYw==", null, false, "be530f86-6abe-43de-a495-e2899f977ea7", false, "Seller3@fake.com", "Seller3", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "22", 0, "9a9531c5-f104-4056-ad78-3ba17bda7172", "Seller", "Seller2@fake.com", true, true, null, "SELLER2@FAKE.COM", "SELLER2@FAKE.COM", "AQAAAAEAACcQAAAAEJPEB7cwiBkwf5jk1azZFGwVAjTg3Pzpvua7N344h39QHoEH36RMfuw/SIn4bug5cg==", null, false, "a550ce55-d0c1-4502-b563-fb91c77ae6b5", false, "Seller2@fake.com", "Seller2", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "12", 0, "57e92d10-9e96-4d31-8f25-1961a3c68dc8", "Seller", "Seller1@fake.com", true, true, null, "SELLER1@FAKE.COM", "SELLER1@FAKE.COM", "AQAAAAEAACcQAAAAEN4evUWcMtEuGVPFBO0OpMKOYy1xEtV0Zc4s/NLdQ9zeoew2ec2ahtWqs/aKN90YTw==", null, false, "25b4e98b-be13-4e3a-841d-7aed1c1747b7", false, "Seller1@fake.com", "Seller1", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "62", 0, "ac9d3d8b-f616-4d78-b93a-c64644f7a664", "Seller", "Seller6@fake.com", true, true, null, "SELLER6@FAKE.COM", "SELLER6@FAKE.COM", "AQAAAAEAACcQAAAAECaY1n+VylpQwkdWCA1G9v5Il9VrTL/bTglBkKiK9dQ0e15fvhuPaNbYuET7AI0Kfg==", null, false, "ca71fe58-9a1c-4cb0-b675-d736bc3eb938", false, "Seller6@fake.com", "Seller6", 0 });

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
                values: new object[] { 94, "NotiRole", "Customer9wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "91" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 64, "NotiRole", "Customer6wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "61" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 34, "NotiRole", "Customer3wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "31" });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 2003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 20, "22", 2 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 3003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, 30, "32", 3 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 4003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, 40, "42", 4 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 5003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, 50, "52", 5 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 8003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0, 80, "82", 8 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 7003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0, 70, "72", 7 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 9003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0, 90, "92", 9 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 10003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0, 100, "102", 10 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 6003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0, 60, "62", 6 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 1003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 10, "12", 1 });

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
