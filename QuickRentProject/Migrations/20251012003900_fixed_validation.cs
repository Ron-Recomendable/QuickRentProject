using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRentProject.Migrations
{
    /// <inheritdoc />
    public partial class fixed_validation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acc8cb9f-4aad-4114-9938-4c31b3c70869", "AQAAAAIAAYagAAAAECt2eKKSA2qEboSAuW7DqsFZji2lrI1ARGRM+91XoLFY6EnaF5DE32WatcPv/UUYDQ==", "58ed6d26-ded7-4ecc-a62c-62cb05873e27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd619406-dea7-4999-8f4a-d2bdde1d6613", "AQAAAAIAAYagAAAAEIbW0tC1WKDWFsPaAhgnzv1xpDr/SmTHG634O8ewtquYvUhpaL+CJcstcoKTE8ONuA==", "0a42296d-6f5b-49b1-811b-2caaaf7b2bcf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8008ae6-d3df-4568-9eb2-53021004479d", "AQAAAAIAAYagAAAAEP2c2h3LBFBKBFWQVzWpmR3bpvpKEfUMTCPF33O7qqZl1EUtL+0OyAvjXOO/DYm0sQ==", "10b74fc9-570d-4172-adf2-4dfa46b763ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56666711-9d86-401c-b4a2-63616bb50dac", "AQAAAAIAAYagAAAAEO+d13YIvv80/G0DAmp4vVKX2tu2CgYUBg7t4FczRR0IQ/A3sDVSU8SiepB/9Jm1+Q==", "ec8ad9c8-04b3-45cc-aa44-9055d59eb836" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd038630-cba9-4529-bcb9-0f488e7b34c8", "AQAAAAIAAYagAAAAELlHMa7jo2nVlWExmCwhX9xnNSU803s0G9CQ4xW6ysAhzxmQejjAJJIggc5Vxelyyg==", "fe3715b5-0d4c-44a6-aa11-ad51072abdad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a7dde38-c98f-45b1-9a3f-d779ec93f3bf", "AQAAAAIAAYagAAAAEATnv5ZKmZq1QtN/O9IyQXCkv6EM46cnzoF8V99GhzxY+gIpwjQUvTcCAc+8SZjZYw==", "3a03c885-f3c0-4446-970b-a821391bb00f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd460292-00ac-4022-8b30-a5e2522c6834", "AQAAAAIAAYagAAAAEAz6AbFWSdTCu2mRLfzickVNVm1JHEhF+GFDpewwWWom3az8/Di2X7un5HE4nhupPw==", "f2388af8-65bb-4a11-be07-363eb16d2404" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "817630e0-22d2-4297-8ba7-1400e9626283", "AQAAAAIAAYagAAAAEBfWQOl9onJ2YDFrOZEN+VkRrhXr/j8rN5Y6W+atPsRdkjEc3jlC6LQu7ejGFvZQGw==", "866c6a33-a3cc-40fd-a6b3-e2739b96d248" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57a91747-8ad0-4338-a09a-192ddf244774", "AQAAAAIAAYagAAAAEIuZuvnQt+Ui3DRWLJ/JZCR7LpE4zQZZygJu6x14OfEKJjjmUT0933JD+lOKh+tI+g==", "885a9624-d996-473f-808b-292cb516f2d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12e12bc1-3e4f-47e3-856c-18af4f6bfe8f", "AQAAAAIAAYagAAAAEA/NBcKOOn0VDSR7zCUKBaG12M9ksH5Yl48TILka1nxyLlOYIOKFYR3Dq23dbZeD6g==", "91318bfd-de14-4e08-ab80-1e0dd1d359db" });
        }
    }
}
