using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISProject.Migrations
{
    public partial class OrderModelsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Customer",
                column: "ConcurrencyStamp",
                value: "186b141e-6c78-437c-adb6-85ed9edbbf69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Manager",
                column: "ConcurrencyStamp",
                value: "e3af1a04-b04a-4d23-8360-97cd4947f05c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Seller",
                column: "ConcurrencyStamp",
                value: "34c07817-ac66-4938-8e0d-acf9b7b6ba2f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9c3d946-c630-461d-9768-0a9371c2649a", "AQAAAAEAACcQAAAAELnMfC4XY0KLOcngnr4iTIc+9w5VUq2Rd+mIJnlQ17fzxf03KgL6oq0s2F5ry5sSTg==", "9c245f42-1d6e-4c8a-83ea-63f41bd6b018" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "542fe550-1080-4217-823d-088840741986", "AQAAAAEAACcQAAAAEDNzFh2s/2kewdHpEs6sB4Sg8KG7/OKEzksfOY2uRHEA6vfdT30Pk4yFVbMjMqSwPQ==", "6fecba5c-4aa6-4269-a26d-c584d1be8778" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccf0d39a-b2e1-409b-b160-3d9905f8a433", "AQAAAAEAACcQAAAAEFxNQOlm62wBIfCxvNpyfAxixm+59sERsmF5fx7O63FlyIGeMP5iazLyl0qsPVLPjw==", "1103123e-fcc4-4f84-8fb2-800f17732149" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfeb8642-eb75-4db1-ab59-4322a6d87c83", "AQAAAAEAACcQAAAAEOtWQ+Ybjg1Hy0xhL+4kZGxsGofF+eE/F7lNVdrAwjgtv3SixsQcs8kt4+d+nEIWgw==", "d62eec4b-912e-4c7a-be5e-80abf27c3cae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbd2635d-f9b0-4f40-811b-6af362a19a95", "AQAAAAEAACcQAAAAEB5hljBXZp7QJx/+PAcIu+mBp12prXfgji6VoQxJ/c2+2wr+cXS0/KbS52ZQ5SZ/sQ==", "cb2eb3ed-fde8-4699-81c3-9f79f1e8bbb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dd2e248-b628-47ad-95dc-038afe743f40", "AQAAAAEAACcQAAAAEGOJI1suBizwsM2pdEvfjGqfU4wQHAs/0MRawU0YlC8Hf26S7GenTOsCAjGAl1jiXA==", "ed44caff-88d2-4daf-a324-c9bb1532f692" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef94d385-9741-43bf-b983-5482fcab4819", "AQAAAAEAACcQAAAAEAFKw5SRIGGguXrjjn2ZFL9z7XLJBhX70s3NKsCdhkzPj1npJNUlHFxHT1YOSWV+yA==", "ffbd7ed3-0f4b-4fc0-983a-d32b49e5ba78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8297ff7d-dbb9-4955-b31f-0a4af4fe5289", "AQAAAAEAACcQAAAAENYtSqURiGYRNfz998qk9ec1D7yEE0bpmklFeLXwpFmTfVMpr9b5XefS4RmS/AcynA==", "8d2f5098-4eaf-4b23-a1f0-734ac54159bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbee4d48-c996-4f4e-b0e8-bc0d9e76b74e", "AQAAAAEAACcQAAAAEB19AXFqAuyl9C0eGb2PT+vfDHvklBj6DvsRGekdCZElVu/nIWAWcxi7BPeXSWe4uA==", "c4d0cd2d-ddea-494b-90a3-6adc4c1c0ef7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2f896a0-d2d4-4d19-a75c-89551e6f1891", "AQAAAAEAACcQAAAAEC4ErMHBkVytPbLTfp9HW4TkfOiSQw55voE33FIMiQZ83ufVnGxZc7qYWFGOrjAg7g==", "358c42f1-be90-4758-816c-e3da71ae49fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec4d00c7-6b68-4ee2-9f42-49bd1fafb3ad", "AQAAAAEAACcQAAAAEC+7PPzxXD7fg/Rz50Di/GjsilsF/7zGxyr6fHhJxeooIAwmTLDGvUTyud6BkIH88Q==", "29219bc5-f03d-46ad-b390-5c83e57ec58a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d302fb3d-4e07-4ef0-97be-09cd3b82b967", "AQAAAAEAACcQAAAAEC1EK8VBJqYxQCZ03Vn0b6G7VJ3NgNsRKLaF9n2ByO/lA6Gv36v14rn/4fjMGRkMfg==", "81297e8b-1c0b-4fab-98e8-6cb12103c14b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf2daa7d-7bec-475e-8de4-cdf099778088", "AQAAAAEAACcQAAAAEMDmg4YiUN5WgVQEE8vqJSx9l+3u+m7oaCo2PkzpwcoxLobslFtu6qxXlNa2igk/sg==", "d62756df-fd2b-4054-b295-677ef6092f53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21123111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5f16251-0aec-404e-bb8f-95834dc6ec1b", "AQAAAAEAACcQAAAAEFmjNNCz/eUoyKPELleVvdE8FcLYOSixcXTS7YnKtyQrbdx7fvy8Fk5d9vyliYcf8A==", "81bfe3cd-2d98-4c1e-bf8d-a07f83b69a11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b396df53-63e3-4b28-815e-a1edcaf8a333", "AQAAAAEAACcQAAAAEFBhnUiGRUote9xef/g07hq+48Ob1Whv7OlkTHFdpg9LcaVujWeQjcna2CkjCBoIVw==", "0d339420-0e3c-4ade-ab82-47fb61d9899e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "550422d5-afff-493a-89d3-fb6d373a53ac", "AQAAAAEAACcQAAAAEGxQKYA87Dzf8Gpmzrxqhb+QrvzzDy3UWN3kxVt1TpQ53yGh8UnkVr8CMNUUX1MiRg==", "e092c585-85a4-4695-ae2e-cdc0ee1b14e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dc096fb-dbbf-4de2-9392-455bac0bdaa8", "AQAAAAEAACcQAAAAEMsh1JmwjWUXEKvyxC6+9rxEX+iygzG45TzkQlXTIdIlbXvNI5ypZeQgZ0muC/dslg==", "9dbf0fc2-be7b-4c57-ba01-b62520627f91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fff25a5-bde2-4c05-b47b-19d85d928044", "AQAAAAEAACcQAAAAEJ8kEwn64Ya3xIh7AmFZyCAfyTRQ5tyJxDAw6P1F7VpHOaiwS8/xEH310UMdgj9pQA==", "a8d443aa-e239-42e1-9ab3-37ae421828f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06ca443a-5f3f-4cda-a576-05afb96e6341", "AQAAAAEAACcQAAAAEKtlrZ2bB1Hz/Ox+yH/ad1To8XtlhAg3u5FkHf5/d2y1cEDhwxMdqkSAsfHcRvfKSQ==", "265a8b15-fe12-4844-8be0-8052c88d2e06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54240051-47fb-4d27-ae05-508e8bfcb7c3", "AQAAAAEAACcQAAAAEANUfRIhAASch7o8mdu5VimMX9Wo9vn7uvQL1glNRpK7j63ZpkJtf5yyz45n6BIuSg==", "2799747a-b546-4f4d-8585-abd0a59bb2e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bcf2ae9-fa64-473b-8963-08b87f02029a", "AQAAAAEAACcQAAAAEAUpcWH+IKxLcjnkGYmNBW3aFnJ0u/HlsqvNcFY+eE9O2+NEw1JnYvsWqP4+FE8gIQ==", "c6217326-f1b9-4352-90d5-ff486f636efa" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderHeader");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Customer",
                column: "ConcurrencyStamp",
                value: "6e4b95ae-e639-4f83-8090-7b49147f4a48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Manager",
                column: "ConcurrencyStamp",
                value: "7413e8b7-10d7-42a7-9a7b-89ac26862257");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Seller",
                column: "ConcurrencyStamp",
                value: "b99ba49e-1d8d-40d7-8566-c738ded0beb9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4aa0e44-8559-4210-a37f-d37251fb963c", "AQAAAAEAACcQAAAAEB6B1xzaCVKJSsgedfqUKGlAhfL2oQNYtlAvjYMU0LLST3hUzH5f8udY6Caf0rfY8A==", "92620c5c-6355-46c5-aa35-9c10944fb669" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb4fc66d-9639-4580-9056-38215e2a2507", "AQAAAAEAACcQAAAAEBEuih50w2dRHg3RH+CrcAaUS/pb0zU4ERq3tZPCEox0JzZ6mzelUy4lyJ0ciGPBQQ==", "21683c6b-d509-49ad-90b8-a3fac91400a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "088cf06d-fe30-4157-a7da-4d7e0a08269d", "AQAAAAEAACcQAAAAEPeK9BueV1eEFK2FI4eJ9gaQRoydPF6+XF3O/jF3HqvQwTvg9yUNFy7wVsxBEXUJzg==", "161226d4-e641-4e6d-a18a-2ad0a153647d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "399419a0-1a04-4698-97b0-a047730a2dbf", "AQAAAAEAACcQAAAAEDZXpIFFtRefXPEgXoKnFYxq7LxplTRfhkrKg4dpCIQkHhRv6THfzNpg0TjAmyV4WQ==", "dbfba477-acef-4f1b-b690-bbad5ea58433" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "588f57a9-6800-4b2d-b58e-0d88e677e8ba", "AQAAAAEAACcQAAAAEDO0dXcxm0ykc9r9UmVb555TM1OOYQ1QxNOv4S1sbxsyOgpu9CSCLl2Kl9pcpCpp4A==", "d3c290a2-3af5-4c70-bfc6-56a6830a10c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a175194-f31d-48ba-8050-282da8825556", "AQAAAAEAACcQAAAAEAelNp0MZExjfMLZd1PYLO3zFEHYn2fjFYCWCh99j4rwf+CbF6PaOLgJl/AQdPomQQ==", "b898bfee-9e0e-4764-8fcf-2984705036b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90124f0b-74c2-4761-8f6e-4390db421fd6", "AQAAAAEAACcQAAAAEMO8k6l7MgmA8W0qCFdFuq/P/miNAopn6lPLRuuQwyB0wjfPsW2PPGfyzSv8Ja0+8Q==", "89ac122e-2f86-4d4d-9421-63198a10cfe9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "120f3116-131d-4f28-b6bd-dce45961278e", "AQAAAAEAACcQAAAAEEGBvr/YkN0nLLdJrTZfC5N5sQyT0Jqiy/DF5hsMF4dUY/n4mwM+838BIkaV5CR9cg==", "19e8c25b-2d56-42e2-9518-d815b6f0c273" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21917b5b-8726-4798-b953-aaae56b70b1a", "AQAAAAEAACcQAAAAELhy+BjKFXaWzGjchGB8dbqXeCB7pJP2S9eN11fTYM5oatuAvMgF60iz0OK8F1k35w==", "0dccf09e-b921-42d7-837a-f70d0ec67f07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2958c2e4-6c38-468c-b758-b7d4d9aa9fd8", "AQAAAAEAACcQAAAAEP0FIgqJC/5UjVAvFIToLvJuwWo0zuDVr3Iz7s631dzm4YmgCDdzEs3LoUNjo++m8Q==", "9ad6d8fe-0f46-4df0-9a2c-8f30bc1aeae1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dec86696-329c-4d21-8bd1-dd200b7a9a53", "AQAAAAEAACcQAAAAEAI4vKxekxZeGugiKfAbYdUiUieMR3ZVRWt4dabcRbnRzzNP7W8kMxhCxgYcrk7cYQ==", "816c8ce9-51f3-4785-a321-5126bf2f8b0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff3eb71d-7892-40fb-ada3-60442acf78f7", "AQAAAAEAACcQAAAAEDP+AH1fQmvIf9pq2YyupGJU3zqpLiCxwUL0Tg+D8sOnqLXTvuKyaPBEpQnB9MjEug==", "d43b32d4-49ee-47e5-b058-f589722ddbb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11a1580c-14aa-4767-8c59-024c5b0f325c", "AQAAAAEAACcQAAAAEN82ivXwl66ndow1Z7TB5gy22esjVIWD4gzDOT2NyS7qK035xuDusxLwPQBXO1jqkA==", "217a0ee1-e7ea-4b74-bc79-012ee5a44b76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21123111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11d64849-b67b-4c7c-b10d-7c0be5500b0f", "AQAAAAEAACcQAAAAEBIj6RS4Wrh7BdhAc85EWLt/wHYBUyXraYfY8yn+fB188p/EOziqTX1Y26bQQwjbYA==", "e459432f-495b-4778-be63-c96efc60a564" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35e2e616-3fd1-47e0-be2c-d97f3503fbe5", "AQAAAAEAACcQAAAAENPFm37cUVUcj58/EFcIN2ph7PciALCS4zWOc4lFjj1KoIBGQrxNFZdpl2Tl/4MECw==", "140e4b08-a13f-4d0a-9922-0a0b85593485" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1c45ce5-7dff-4332-944f-227e0731e07a", "AQAAAAEAACcQAAAAECf5VNIxc26+ki9Tq188rZqAsXJMoBokEtHZ8x7jauQ/yZSeoHjGqz2dWYH6xqoqNw==", "5c3d9eb8-b67a-4e47-8fd6-4008c93ad41f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fba28a5-1583-4046-83fe-279be3bd02dd", "AQAAAAEAACcQAAAAELAaCPRBIlhg5E0I+zXnM5QyAlxw3UmBRX9a/Kr3LXyjsgM3bsrBtcvJSM9EGdYIGg==", "c3ad8031-77cf-4e39-9374-647e3cfc7dd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbaea7c5-85a7-48ac-945f-d262aa9e7090", "AQAAAAEAACcQAAAAEHp72EldOkbLg2xMH03cz6JVfVE5zEitnYDhM2XMb19A+ZcRgsKCb+hzlAnC/hMA9Q==", "b0abf306-73fc-4849-982d-1f2b17c2dea2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0390c5b2-cd8b-4c1a-99f2-457021bd3a9b", "AQAAAAEAACcQAAAAENFkdxFSmiPD78wYoe+YrMp51lSDM6ZyGVjOKQk7wE4JaTasL4VOA4ZaHR3XmnLqhg==", "85f37d90-f920-43a2-80f3-8532d085c22e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f396d64d-115e-4fac-a5f1-8979464d1309", "AQAAAAEAACcQAAAAEBbiNq45U4W/j5klqaKoM0a4CwT3EnFeQd2yDNMA74i25LgK/OzwoClIcRrRUhD0Jg==", "0b6568c1-63ce-4b5e-b1b2-b6be2ea15abc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1d8f364-4f90-4995-9dc6-14f7f1cf8e1e", "AQAAAAEAACcQAAAAEA+uYDjuMBxLeGp5KwMG6NB+TjIlR55+cd/uTgtBUZEENt7h/1eNDttYF8k1U3s2dg==", "11b55bee-e42e-4110-a64e-525ed6280f48" });
        }
    }
}
