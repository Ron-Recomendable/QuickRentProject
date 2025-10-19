using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRentProject.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Booking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2440513-86cc-4f6a-9f73-82e0f88d2bd7", "AQAAAAIAAYagAAAAEMKvJ7T5bnBOAuAsKkvPu+P9niUyQDoqYFL7FNDcilmT+MzL4NIHXX3APBGCUA9dPw==", "554b60ce-d46b-40ba-8b52-390bdad50335" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c39f2f86-010f-45d6-8b1d-e4575c1df564", "AQAAAAIAAYagAAAAEEc7X2xwcCWJy8SMcuu659afmyZti9VVlRn0YZ72XKCJTuG7ICE1XoiOsmwmlXOdDw==", "cb64c913-3f07-4505-acf0-8b6ae0f6b7f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e92dc8aa-1780-439f-b152-3f95a1223729", "AQAAAAIAAYagAAAAEGl9PfNtJd1r0PrEx+KfJhJjZhiMcTrfIWQIUoMoGYvkuvZsr80xpilsYlJW8t7f0g==", "41a654a9-35a5-4ca0-b36a-566ea26e1514" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "652d2503-41f1-46b3-9bb5-01104fb02da4", "AQAAAAIAAYagAAAAEFjS9ZP2/XFnlX3Rh29r7MGmZBFjsoS4pUEYHgMEZEuALs8UqqXdKlHQlYSj9WmBkw==", "c822873d-4269-4b9f-8480-cb9d58978d70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13d0b647-1aa7-4139-a950-cefb7e296cdd", "AQAAAAIAAYagAAAAEH2TWUoO5lONn7cSOJ7wb34eiBRytn4oz6A7FoWca2oED6V1gG2s9wSZvN8982o96g==", "0fb26ad0-c61a-4358-9cb3-d349562a0e44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70787359-c9a3-40cf-bb8f-2fa445391be3", "AQAAAAIAAYagAAAAEF0WWc/stxsr9ckvRaUuff1DC4AzrSjF8ydPIMjjUwRXSiePQVuKEiB+9qIAjwjpzg==", "7960acc3-4f75-47a2-a37f-89f997179c96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59286af4-e4da-46bc-b8d6-256116ec5db0", "AQAAAAIAAYagAAAAEJPSVZdQKLKVvWRybz4IrhHQJ9/J3qDbK8AlWb2xiGQzfZiKYUwlElYdeRLjblt+KA==", "4989759e-068f-41cd-a192-80c30522c91a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc9e1218-8ae1-4431-9b37-a6a87cd5b68c", "AQAAAAIAAYagAAAAEF4bJGhizWDP+s4I/CuFFTtwxmWI/gUiWd6Jb5zH5/ceKtxHxBsis2LrjMyJssVoxA==", "031aafe8-a04e-4907-93df-6076fb28ed81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f136edf-c9bb-4c53-90cc-c66e58186b66", "AQAAAAIAAYagAAAAEImT+8jDASmXPF4TFXSNp7mbLlwTcKpaSm8QdAqNdC9yA0QylldFbZXjNNcQkaBAbw==", "c469b283-04f2-4a1c-8544-b49fe853d1cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7af3328-b550-4fd9-932b-f84ad3133a7d", "AQAAAAIAAYagAAAAEJITjEJ5YUzqXxTaoDwRpbseTbAQ5eMU4fAsgEigekSSsMMAwDFCbvDzv8wahQsZRg==", "74ea62a9-784b-4695-b26b-c0a64741dc94" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Booking",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5269c1db-0a76-41f2-954d-8b5c067f13ce", "AQAAAAIAAYagAAAAEP9hnfTycNLDG44nXCwPV9CR1IGQsh3iD4UvIMzFLakqJKk8byOVmZhLGXxmlhethw==", "e8df04ec-dde6-4276-ab53-cd58f13a9ee8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c499cd2-6c3c-4c0a-bcef-1bc437634357", "AQAAAAIAAYagAAAAEPV46WkSq++bQyPx8OuGg/M2S00fJL6rNh/17ZlJCu188zyYgkQLWYaNL0d84fQx6Q==", "d6bf2704-96f2-400c-a921-d7540eec910d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8483c89b-99e9-4794-b732-a2ffe6deefea", "AQAAAAIAAYagAAAAECNXtEpTQEZs5GEj938t5Ov701ew0H72wtKoINtZrnqM4Jt55c+SNVD7FLitRePVJA==", "0674cd12-0e54-445a-b4ae-6f24614c4502" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68d06abc-2973-442d-aa95-783ce8690195", "AQAAAAIAAYagAAAAENFpAgz4jp2nezLZEPILjPC6mClo+Fk4FeSpGRmiQy1oF9wBE6mX1ZdIDMQ8bm+gww==", "1b6c0924-4968-44fa-9292-6b0e26552a3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb84fb69-e913-4ab3-93c6-6494b5ec4c89", "AQAAAAIAAYagAAAAEPCzTRuxLPbWvHMVfckYiZXCLtixfadVTiH6aykyRM9ty2hitDeiEsVWo8Yy7xgivg==", "1d91166d-b19b-480d-a723-95ce638b645e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af2ed7e6-bfee-42dc-9a52-4630f41dd370", "AQAAAAIAAYagAAAAEDsOO/Aadfb5nvmXcWHOz6QYzuHChkRF9ZyNXdRk2vu8NNbZTqJutq+D9TCo0F0WHw==", "2bdef713-f211-4f69-8e38-65c5a7b7f0d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d7ef11b-e199-45eb-8eec-907f717d6732", "AQAAAAIAAYagAAAAEEw6OHVLsx4jtwxB2bb/cbH5aPRQYLRb+vA1XjEH38YeN8a57LtOCNMUbYiUB0ps+A==", "14f6b6b9-8f61-4597-8699-4a5bdfb7ecb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab711494-cd9c-4308-bcb6-8ba6fb4e824a", "AQAAAAIAAYagAAAAED1U1wpkEKjYxCH1bFULdMzvE1WkahrB2nDr3XXRMwLBB2jIu3rgOtI+1QH6bAyxpw==", "8fcb7a0a-b361-457b-a2d6-e6a68319f8e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6d63b6d-0b1f-41c1-880a-128a1ef82feb", "AQAAAAIAAYagAAAAEOoGzswHipTpP9Fv3u0NAHfoL5sZt1iQL5+d3/bsMeWAD6flgbVxfENMD3k4XDW9yw==", "208b718f-2758-4652-9ce2-8b7a4f7a6277" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f4cea2d-0bb6-4170-b505-a73c3a41930a", "AQAAAAIAAYagAAAAEJ39uYgpHiNfh9rRsERa2jwQRhiIpJp8mNtkjmXQKL6cvxuUP7RDe4i8Z0YcAdDJRg==", "68063479-7350-4593-b312-6170491110e5" });
        }
    }
}
