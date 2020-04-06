using Microsoft.EntityFrameworkCore.Migrations;

namespace ISProject.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Customer",
                column: "ConcurrencyStamp",
                value: "d4aa92cd-8eec-4c55-b7e5-04da8de58d5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Manager",
                column: "ConcurrencyStamp",
                value: "bfe056c6-0752-43c9-8aba-833f3036ff34");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Seller",
                column: "ConcurrencyStamp",
                value: "f3fcb4c8-d003-4449-baa6-bb14eb15938e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51a659d8-7a79-4d2f-bdf6-61bcc046c559", "SELLER10@FAKE.COM", "SELLER10@FAKE.COM", "AQAAAAEAACcQAAAAEMyVjidpK8ltmIuoC50XD/+uL1VKQvumv5cX+hDuPKipcDJqF5iW8W30xq5N0ymaNg==", "d83a04f4-255a-41cd-8021-1bce23fff5e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b2df839-614c-4bf2-aac1-540d1bd1594c", "SELLER1@FAKE.COM", "SELLER1@FAKE.COM", "AQAAAAEAACcQAAAAEDwNZfocPBCAdpS2F8VvkcAS0QLHB5IH1ICnZyzVEAuAR0I0ofnhtdBTkDRwuxEsQg==", "74fe9148-b04d-4869-a433-2cbb68c376e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19c89ad3-be4d-4822-a5a5-4f16a66c4c77", "SELLER2@FAKE.COM", "SELLER2@FAKE.COM", "AQAAAAEAACcQAAAAELcEG242mnCuZpQmpuOnvlV7YqU1wJQ6kUEw1BhXdoPsUwBXK3YiQS/31NmQTuxJAQ==", "439f7301-f035-40d5-921c-81be41a39a92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ccc1a83-59c0-4a38-9faf-060d6d35f012", "SELLER3@FAKE.COM", "SELLER3@FAKE.COM", "AQAAAAEAACcQAAAAEFvPVbtIWhikxr+PK0alYuxKSAMm4qIG7TUrw0JX/kDknY42ni6E2sr32kCsri4YMw==", "b012d888-4d49-4e70-89c4-afcd9eb1bb17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d2eeea8-edc0-4570-b010-9bd2c2d34eb0", "SELLER4@FAKE.COM", "SELLER4@FAKE.COM", "AQAAAAEAACcQAAAAEL8DacoQg2XHFIPzTtvMMUnSZm/wYx51JAl2vePVLW+gv4K6Bk/NH89bnf/ZCJqT1w==", "13105522-5f43-43e3-86d4-60ab07f01489" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd9565bf-b632-4ca5-b47b-b33620426e5b", "SELLER5@FAKE.COM", "SELLER5@FAKE.COM", "AQAAAAEAACcQAAAAEI5JsHC2+SnvBT7/rYKoGuvSeMyimWFCGjuOxLT+rjuePKpmgi87uGptD2GGZT+dIQ==", "b3df08f5-85a9-4ce4-b10b-6c76923471c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07469ad7-cfb9-4224-a999-6b360237a088", "SELLER6@FAKE.COM", "SELLER6@FAKE.COM", "AQAAAAEAACcQAAAAEN43qzTykDOwHna1FSiHt0gCN0Ve7qSnljDSMdPLOrK8wziRdG4wxLxNRceYEqogCA==", "65b7f70c-a348-43f1-9fec-fc0b97abb0e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "222980a7-b119-456c-8d49-b3f5c05dd84a", "SELLER7@FAKE.COM", "SELLER7@FAKE.COM", "AQAAAAEAACcQAAAAECQE00NbDaAfwJKyA/WHux06KlFeef2crb68u906V/dvg9+MOxjOWfAUcOndGLeU9A==", "6aec93fe-4f18-4183-a30d-218d5e5828d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34113e7d-cb83-48b3-ad12-821f7dc6dd38", "SELLER8@FAKE.COM", "SELLER8@FAKE.COM", "AQAAAAEAACcQAAAAEAyXUUR3jPkfu+L0wF7xA0/+qmDFx21SLhkLjoeKfGNrtEFH7RQQizu5iVCt56ngoA==", "14296dfb-afd5-42ec-84ca-00c7f694514e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a85691da-6d09-4d1c-b591-60aafa00af97", "SELLER9@FAKE.COM", "SELLER9@FAKE.COM", "AQAAAAEAACcQAAAAEAFwiSh/cRxTLUmGvMIaEqMNeokPlxRGfiL6hQBWCQkyYC43vg3RIj410qDiWQFu6g==", "b68bd55f-e7ec-4b20-ac6d-89ca1ee23f3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3857934b-f72d-4203-b0a9-74fd900007e7", "AQAAAAEAACcQAAAAENz8vzAYRZQUTHJIq3F6gTr6DJpS74zAjLLWavKdTKlZtkemx1J93m0AlLnv4ykG6w==", "15c87dce-80ed-42fb-ad95-70fa68256d75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a8c41dc-c0ab-420d-9200-b0767bc1651c", "AQAAAAEAACcQAAAAEHRj/cTd5wtcUR3DyubDMsVECfuM3VMa12cmHgC2ngw6VqLLbsZpkILdm3sO6nVIjw==", "6c9244f0-fd82-4897-8da1-4a2f6f5e17d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b78c0c1-24c9-41d9-b74f-c96279e240bc", "AQAAAAEAACcQAAAAEDnxolDF82Sn9gqqaeH/Nfp/5QgcHMEi44Z4nIwlAeuf8z2DwW5xFi1WL0BjWWSNpw==", "f5c809e8-588b-4213-a9e0-d27a27ca56ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21123111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9b16909-ec46-4528-aae4-d6a2615da9f5", "AQAAAAEAACcQAAAAEPN8yLKu2SMM8HAYYycFg5kA0jNvqduSJvwcb5wfCICQhozWzH/AjpqH0JHvFvWC1g==", "f6b3dd7e-408d-405f-ae92-ccf32a4000e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "194e7366-f686-4728-9a60-810f5ecc4b2c", "AQAAAAEAACcQAAAAECR3AgIRhKEWZDLMpfqJGIKIZFxVzYdM8BUBtPHyMuYlWjgt14Uy94VQ+nW07GaRgA==", "f9a0fc18-e7fb-4c3f-8623-e032f393330b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a44dddea-6707-4a84-a6b3-d56faeb66e90", "AQAAAAEAACcQAAAAEDS+uskYdchfiMEjQaoW8Z51sg/VtwG3EO2+bjHla2w+7QbqmRnAr3iQNQ3ziok9ng==", "29bc2f63-dd84-46d5-932f-901378e6cabb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34468998-b012-424b-8de2-16009e487cf0", "AQAAAAEAACcQAAAAEGvvShG02IYJ1a4bfMyb0ZjCB89DtOVFMuB133VSf1dh1l4fdz7Mh++29kTlcfg7Zw==", "50ac79cc-fe06-4817-88a8-4056980d0d73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e5c26f2-22e4-4697-a0f2-eedc7e7d7247", "AQAAAAEAACcQAAAAEPuF2/qtPTBxQk2CxGgNakGbV1Pm3wFHfmWIgebn71v0a42pOudKTlAGOAjL60FjHw==", "d444f179-19a2-473b-a90f-e4d6561eb78d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21499da0-5cea-4186-898e-a5229464c2bb", "AQAAAAEAACcQAAAAENlp0C2AvuLCcB+EblT/Ra56q1KwjOmV9MZXi/TSLyzCdIVuPvhfa8oaXLCnCu3gMg==", "2d67f9a1-1f0a-47d9-a00a-b9ab5093c200" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3825366b-ab8a-4c59-b3ac-99371f284888", "AQAAAAEAACcQAAAAECzQhZoEyPxBxJwrzRy7xDC+6T/VyMD9ig/cqhUcAFfN7c0Ru0jHr2NnzZJdNa+KBw==", "ac78de37-d6c8-43fc-8653-de2cede874df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2437bd4e-b22b-4b3e-be43-64419849990f", "AQAAAAEAACcQAAAAENXiPqR/o4i+VxzqT68GL+grc3vhKE5anQOqShJHblAcDFGYV8EyBb2DlBq/vCxUQA==", "6744f005-5fa1-4157-83cf-beaaa61f7dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Customer",
                column: "ConcurrencyStamp",
                value: "2d746177-d6b4-4acb-a1d0-b676ca899a2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Manager",
                column: "ConcurrencyStamp",
                value: "0ac6e80e-b42a-4b83-9bad-41993fb66288");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0Seller",
                column: "ConcurrencyStamp",
                value: "5c5f8347-6b77-44e2-b605-e89e5a2985f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "990bf426-d87c-4178-8765-dca47e8a8509", "Seller10@fake.com", "Seller10", "AQAAAAEAACcQAAAAELIfqY6/m9oukwZGTcHC9Bc42zrUPbohjKd8XulKw1IrOx35yOry7E7a63i0GGidgQ==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da642b5c-dbd9-421f-96d9-edafba4aafbf", "Seller1@fake.com", "Seller1", "AQAAAAEAACcQAAAAEHXUUZMFiID2k/X775g65QGBLSuDvc4UPPMjQwlHrgw6KHTjZiyVHgrtfA8Ra2bRnA==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4aa11ff4-b773-42b1-bac5-f44b3bc8056d", "Seller2@fake.com", "Seller2", "AQAAAAEAACcQAAAAEAkj5F273stpVstFhzhepuMTg27gxQWmUh/fEf6GX114ziPRmWALDXW8jaAcvp0DuA==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c4ebdc5-1f1f-45f8-9484-e0faec0cc94c", "Seller3@fake.com", "Seller3", "AQAAAAEAACcQAAAAEObTFSKdYDzPbIjnFOxnEoebfUnnRomFBGWiXQ5t8lAikyLvgYHw9Nf44PEZ4z5oFA==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16bb6b26-b861-49bb-a882-f11c8aa30211", "Seller4@fake.com", "Seller4", "AQAAAAEAACcQAAAAEHRa0E9GpHdl1CxZY5KJ47Kz3w5akHj8jI/cDfp9WZtxuRYsxbfKrlO5ET4k34reKA==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "490416a0-80e1-4d36-9934-fdd76ee99ef7", "Seller5@fake.com", "Seller5", "AQAAAAEAACcQAAAAEKV3Hi6u37hbBHHZhHbjRDKP//I5/DtmZ5new+Q+87BWp40hDlCP8Bjrs0TpJm5Cww==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d423499-9c5b-4bc3-a512-6cbf39d3bbc0", "Seller6@fake.com", "Seller6", "AQAAAAEAACcQAAAAEOhc/htd/qmmTgji7tvvoDpivJ6EVww+WS3yEiQwiLZTZbsPpcjP82Vl0OLAZ+vr3A==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef6fb5a0-eca0-40c0-84d1-13e258466c47", "Seller7@fake.com", "Seller7", "AQAAAAEAACcQAAAAEBmtfh6R5M6eKtd6TgK2LeHGa+Vu5oZ2zj/EzJko3bkWkO8gPVPI0y0jhTxS/+15eQ==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64087267-bb91-4d3d-8404-7cce374f9a48", "Seller8@fake.com", "Seller8", "AQAAAAEAACcQAAAAEOFcwUE+/Z3ylUXT4/GunBxi8sc3vlmiPSvK4svNAObH5q7CHQseqoAuqO92TuJrIQ==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d7ca325-8d04-4d8e-a78e-1000be3e6372", "Seller9@fake.com", "Seller9", "AQAAAAEAACcQAAAAEC8b8x6FucXZLMfT4+Uy5kh6JiQo+l6Ih13QdcHEKAw5E3adaC5h7gBLPIby7lmlxA==", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "668f5d55-5cac-45ed-8532-a8b4d70d23ac", "AQAAAAEAACcQAAAAEOeA2wv5r3Lg1ZUdB3Km1DUYS4UqnsAr/QiGc28VyFGyDOO17Xv65XbIlch9JaZBdQ==", "c17241f5-821a-47d6-8f36-bfe48db7fb89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36487bbc-9346-4187-90d8-9107f750d609", "AQAAAAEAACcQAAAAEAZma3kPlPz8/QsVImFxTuVmwhaNvbKsn8Nwu4edeurPhc64pUrcMpRvREOYNNu71g==", "7b58a4ec-570d-44d7-8add-7ff02e13778e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7cf377d-fbb0-4757-b0a7-1f650aee5f5e", "AQAAAAEAACcQAAAAEMTXZ0wRh8gkdVvr2ht6H0entS+gnUlZNN71Uy2Jz/QmtRQd1yFN1kZKMVZE8/XO9g==", "257961a5-006d-4260-8ab6-0328d62a84ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21123111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0761bfe8-29b3-40ad-8288-4f8f7d205234", "AQAAAAEAACcQAAAAEN8JfIme3afQE7aEyRT39E8MHWnRTWRM0ZV/TDQArUK8/pUsunlLbMuDk5n2sAMq2Q==", "1136f485-d4bc-4675-93a7-1dd1d75675d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48d06328-89dd-4403-bb9d-e552f74b874f", "AQAAAAEAACcQAAAAENKhGC3IdNJ+ngzy9inkyvqsrkXbpgVumHeDbGR6AL44nWp1B8GwRLFeu/m3b87MIQ==", "a8a2a84e-d609-4364-9c6a-0f96b37f8a4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3609586a-17ad-43e6-a1eb-a47239ecb6cc", "AQAAAAEAACcQAAAAEAPqDA48QHSqnEonqv3upgb8VHrCCpEjeAMz0rY+zWuFIAbPsBUmTrdCL8OjP7gfFQ==", "ccccfa6b-3e3d-4f3b-87d1-dd1fbe688725" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "693ef751-9e9f-439b-82d7-e61ed7bb608b", "AQAAAAEAACcQAAAAEH1/jyEZaHRFqZIffNWSSHb2guiSjanlbVQoaSGnUiiEJA39ZgAWPEJUJS4/XeGaog==", "5efe14fe-a9e5-48af-b36c-9b3078100ea2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3186ff76-f03e-4e4f-aeda-d09a2c9cffe4", "AQAAAAEAACcQAAAAEJsbIunjLyGTyQ2zOdNRbmntxiDw2hnStkaRImYaScKcdrr/MXPFSvflisIzOUQnqA==", "911b6eee-3c28-412f-a6e8-5d9c7c721bcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cc8aede-704b-42de-87a0-3057184a384d", "AQAAAAEAACcQAAAAEAmrDO0MYtvHVlgz5ky+MmWi/RAgV5jcmQqPDmBfBJ90OinX/zAZnR5OMtYHdyXRLg==", "fb41480b-5741-44eb-ab26-9ce2506d7307" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4660da64-f53b-4aec-a961-9a90226c5aeb", "AQAAAAEAACcQAAAAEF3nULzLOrJkzNk5KeMOwS+us0b+vIfoKld+4lPU+fiQD37MIcksN1PcvPeqQ0F97A==", "04c23e5b-9a77-4373-8c0a-5c248bfe274a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7d91e36-56e7-44c3-9de2-ef28fc688177", "AQAAAAEAACcQAAAAEAiSwR9dxcixJL6yuYTx5yYL34nwgy1swkr3Hvxm+q44iE9MMHbuS8DEVxgCSsJrxA==", "efa4059f-ac09-4866-b044-ec95bbb701cf" });
        }
    }
}
