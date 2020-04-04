using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISProject.Migrations
{
    public partial class SeddingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Seller", "0368d1d7-2be7-4be8-a59b-e12091e28595", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Customer", "4a273499-f9c2-4fe9-bad4-44acb719f3e7", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Manager", "7e49f0d3-52e3-446c-b9c7-15687417931b", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "101", 0, "872301ac-6127-4420-b7bc-a28e614358d2", "User", "Customer10@fake.com", true, false, null, "Customer10@fake.com", "Customer10", "AQAAAAEAACcQAAAAEDVgD4M2qxRgoSsBf8DW4UlaYYMqNA4QlI42Pn+/kvIaodm+QHUkmmyQ7XmaQ58mJg==", null, false, "", false, "Customer10", "Customer10" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "91", 0, "fd8f257c-5b1a-4ffa-8f8e-bbdc6e5604a2", "User", "Customer9@fake.com", true, false, null, "Customer9@fake.com", "Customer9", "AQAAAAEAACcQAAAAENDLMfBolR87OauyBsN+WVZQeJNmTx0BEhdjE2kACQpceGhBHm6vd3yLnaalVq5/fQ==", null, false, "", false, "Customer9", "Customer9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "81", 0, "097491ad-0216-47f1-9caa-9806736ae84c", "User", "Customer8@fake.com", true, false, null, "Customer8@fake.com", "Customer8", "AQAAAAEAACcQAAAAEE17XbNvLX5LBr5pX1EgPhPU+GKaggUWuJk91vj71DuWAhp4dws0DrnaGpN2ub8YQA==", null, false, "", false, "Customer8", "Customer8" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "71", 0, "d5b0ffc3-1d21-46e4-8dd1-30d31aa9a05f", "User", "Customer7@fake.com", true, false, null, "Customer7@fake.com", "Customer7", "AQAAAAEAACcQAAAAEBG/kzlM+OmtHjgVmR+ZHNgTP5SDzdec6OdfSvvIwC7I+89CzsGxCWG7zTiRtf29LA==", null, false, "", false, "Customer7", "Customer7" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "61", 0, "03e46110-dcd2-47c4-b44d-6498d5f95993", "User", "Customer6@fake.com", true, false, null, "Customer6@fake.com", "Customer6", "AQAAAAEAACcQAAAAEN4CLU1jx+FHvlvp5x45En2LlKxTlcwCzX9YCBZR2vApBimKZ9+wTxyw66ar9nFVXg==", null, false, "", false, "Customer6", "Customer6" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "51", 0, "d0129a8b-997c-427f-b780-d104ec322f0f", "User", "Customer5@fake.com", true, false, null, "Customer5@fake.com", "Customer5", "AQAAAAEAACcQAAAAEM0wwCiMZWEEqt/KxV3ppM6IvLtt7xAaoVryOgJRe7EjzmbBo84Qm6pF6CnhBbt4BQ==", null, false, "", false, "Customer5", "Customer5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "41", 0, "50013b4a-a86b-491f-9a0f-b426947bed1b", "User", "Customer4@fake.com", true, false, null, "Customer4@fake.com", "Customer4", "AQAAAAEAACcQAAAAEAEWo6/538xBPOSN3DufE7CLNnl5fpMOc7ePMKqoYcy1d4SDQ+I56nsAThkk58Bu7A==", null, false, "", false, "Customer4", "Customer4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "31", 0, "9e0b08c1-8256-486e-9bb3-5882af33ea00", "User", "Customer3@fake.com", true, false, null, "Customer3@fake.com", "Customer3", "AQAAAAEAACcQAAAAEIcYw6wSQmplgVdU4eILEb+HmikbCx0PzbWbENcfkAQL3BSW9U+UgS40OJljXyn35Q==", null, false, "", false, "Customer3", "Customer3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21", 0, "982bfa04-3996-4953-9421-ca218e58a726", "User", "Customer2@fake.com", true, false, null, "Customer2@fake.com", "Customer2", "AQAAAAEAACcQAAAAEHICsVPgEcWltLdlswV+uGzCCK5C79acz6x4JSHItRmbgRYC/E6rz00Wd++5+uGeTQ==", null, false, "", false, "Customer2", "Customer2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "11", 0, "097864aa-cf6a-4a56-bfd3-cba7ec39ecd9", "User", "Customer1@fake.com", true, false, null, "Customer1@fake.com", "Customer1", "AQAAAAEAACcQAAAAEPPh0NafLBX58K6E7TEWPhfmEmN9Jf2OSM/jbX6GTVUEAQde+OIbYY8FQkedyHAl9Q==", null, false, "", false, "Customer1", "Customer1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "102", 0, "86a1fed1-7fef-4160-9475-097700f3f029", "Seller", "Seller10@fake.com", true, false, null, "Seller10@fake.com", "Seller10", "AQAAAAEAACcQAAAAENyKtocpUGtywB+xOPO2T4Tbbot+1/cRmWCzHT8dLRIukYEpe0nXRBlSe9ObCQAqhg==", null, false, "", false, "Seller10", "Seller10", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "92", 0, "ebd0bbe8-3d9d-4c59-88e7-18b89806d9f8", "Seller", "Seller9@fake.com", true, false, null, "Seller9@fake.com", "Seller9", "AQAAAAEAACcQAAAAEAPd4ZIuwvKJfKWNal8Jzxd7HT5VfZqiUong3bp/+w0XPdT0P2b/LfwEq4rp3jqQAA==", null, false, "", false, "Seller9", "Seller9", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "82", 0, "f9842f63-02cf-44c0-bae2-5a385af5ec77", "Seller", "Seller8@fake.com", true, false, null, "Seller8@fake.com", "Seller8", "AQAAAAEAACcQAAAAEL6LlSCTj/35Vr6SKHpnmB0xWQyxfkkAHbP3GJGw98pQaAbPHt0xE/Jbir8TmbBOpw==", null, false, "", false, "Seller8", "Seller8", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "72", 0, "863fb0ac-17ba-48fd-b953-bd0905c3a563", "Seller", "Seller7@fake.com", true, false, null, "Seller7@fake.com", "Seller7", "AQAAAAEAACcQAAAAEBi3O5aWE2BO1Mq8XCEnXrIjoaG9Fo3VViDtF9vJnC8H/fCX9qV7tQnRL8xRWunfPw==", null, false, "", false, "Seller7", "Seller7", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "52", 0, "ac771171-f0bc-4cda-83b9-61f8e69d1b6e", "Seller", "Seller5@fake.com", true, false, null, "Seller5@fake.com", "Seller5", "AQAAAAEAACcQAAAAEJKMaXWKAC25BfAnKzJDW582o+8lnIzP/96gNF4X3y0TS1YIw/9cuzO9ItiT+OBqzQ==", null, false, "", false, "Seller5", "Seller5", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "42", 0, "dbdff921-c806-4d4e-acf1-1e59afd8383b", "Seller", "Seller4@fake.com", true, false, null, "Seller4@fake.com", "Seller4", "AQAAAAEAACcQAAAAENt0iktO9r6GGdJE4fp2FH5GXhaubeQsdjatnJZcGKm82ngkn7q1Qglhnp7+okJGCg==", null, false, "", false, "Seller4", "Seller4", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "32", 0, "d282fa26-f5c2-47d3-ad3c-925e7254f708", "Seller", "Seller3@fake.com", true, false, null, "Seller3@fake.com", "Seller3", "AQAAAAEAACcQAAAAEC8uHsgq+1YmdqoWiW5zva1UZq3NfWTq57cNasVmpkc+S7PhOsq92RSDi+9judG7bg==", null, false, "", false, "Seller3", "Seller3", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "22", 0, "ebe4c87b-86de-402f-a689-146d3948d549", "Seller", "Seller2@fake.com", true, false, null, "Seller2@fake.com", "Seller2", "AQAAAAEAACcQAAAAEPM2njTwUMrpQyFlXkArkFRpN/7TPhB4QWJRilVP4m8ot3czx4XXUD3GQ6oZz/vxrA==", null, false, "", false, "Seller2", "Seller2", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "12", 0, "b8b55424-c9b7-4a30-9f7a-cde636c65eea", "Seller", "Seller1@fake.com", true, false, null, "Seller1@fake.com", "Seller1", "AQAAAAEAACcQAAAAEBmBgrilJpMDDVmd+pZp8uv5Dz0DIKXq18dCIJ+camENoPkAareV/6U4RwyDpcSJJw==", null, false, "", false, "Seller1", "Seller1", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "62", 0, "64007f29-8eaf-4859-8ee7-b6c27bb54a56", "Seller", "Seller6@fake.com", true, false, null, "Seller6@fake.com", "Seller6", "AQAAAAEAACcQAAAAEBdPbKWdsNMYKaIJJdV++z4UN6jc4HHjFfSacPjnAV6THeNPAZIo+xHgJD16XnuvMA==", null, false, "", false, "Seller6", "Seller6", 0 });

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
                values: new object[] { "51", "a18be9c0Customer" });

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
                values: new object[] { "102", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "41", "a18be9c0Customer" });

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
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 10003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 100, "102", 10 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 9003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 90, "92", 9 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 8003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 80, "82", 8 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 7003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 70, "72", 7 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 6003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 60, "62", 6 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 5003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 50, "52", 5 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 4003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 40, "42", 4 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 3003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 30, "32", 3 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 2003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20, "22", 2 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 1003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 10, "12", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Manager");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "101", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "102", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "11", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "12", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "21", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "22", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "32", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "41", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "42", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "51", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "52", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "61", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "62", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "71", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "72", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "81", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "82", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "91", "a18be9c0Customer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "92", "a18be9c0Seller" });

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 2003);

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 3003);

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 4003);

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 5003);

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 6003);

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 7003);

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 8003);

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 9003);

            migrationBuilder.DeleteData(
                table: "ProductSale",
                keyColumn: "Id",
                keyValue: 10003);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Customer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Seller");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "102");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "101");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 100);
        }
    }
}
