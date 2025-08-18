using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRentProject.Migrations
{
    /// <inheritdoc />
    public partial class ProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "4d73da51-1f04-4e46-ac6e-f379643d7d20", "AQAAAAIAAYagAAAAEK01uXVBHyqLZj9CbIUIv86zcL+8gZoNnl7ZJDAx5QAJFNVNoUEFyln3UBW99dBR1g==", null, "70dcb800-6a1c-48dc-be44-9c20e80e1237" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "39d5c093-515b-44e8-836a-65b7da47ea01", "AQAAAAIAAYagAAAAENVLwWYBIEmi4+nwlSTyyghKkmr4tpLRmDDsGpLVXdvJOgceptNCWnlgG3+NOnJwVQ==", null, "a3087956-1cd0-476b-9382-bfef89f0fddc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "101927d1-ed0f-4121-b222-053586c4247d", "AQAAAAIAAYagAAAAEFxJL3h0SlG/RTp4x1g4d0g1SbYVcL5Q254N9MsJKUYKaMSy/CGRW5udzVB2DS33Yw==", null, "57e1daee-0fd8-40cf-af45-187b8791d96e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "33c45fde-1ddd-4f6d-a8f1-e25d43e9d9db", "AQAAAAIAAYagAAAAEByB25Ej21EmgHxUrSHN/LHxW/0tJGaueoffdiuzaIrTyQTpJrhe84xQjf8r8SvBkw==", null, "770646a8-bf06-49eb-9844-b64e95c68770" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "53c65f7b-b10f-4bbd-9f2c-15777fe57017", "AQAAAAIAAYagAAAAECmgPdmTZNsslp5ZAu5Vb+4478WfkmWlRJYXGGNAPCugaS0PFddPZLQ5E8TXiGTqLA==", null, "c373cdcd-13f0-455a-9472-40e6d2c11354" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "0a10c0a2-d586-45c4-b362-35eda2a96c8f", "AQAAAAIAAYagAAAAEIBdPNdS0/Nq06jKJpG7nzQ33LmqO6nRUa1MCVxuU1//arb4TyGtpsBeXwnOqNaNMw==", null, "ebdf7e7b-9f48-4383-a2a5-f01c715c9fca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "ff341ba3-304f-4681-904f-f0002f10632b", "AQAAAAIAAYagAAAAEIVHAFSUnKUG2Wtno5GroG0dR49Vou5mb+c76nI7DI5OSYTotu3AJhP8QA3kmJXPcg==", null, "43c7f6b9-0eec-4677-8e5d-87e31e64ca21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "cf4e8984-910e-4736-8a5a-59c9c492ea61", "AQAAAAIAAYagAAAAEHzsxYzLbTDiREgHGprrRTZ8pgdmXfRnqXUh9uZ/FX7pVz/k+f8pmPEQ2rY1LAVMgg==", null, "bf7b2fde-7492-4778-9eb5-5b0fbb3068b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "84599080-192f-4dfb-a723-5b83be1697fb", "AQAAAAIAAYagAAAAEF+fVkGLF+kTGMmzuy9SitxxiAuV5+LHe4+u3Jwqws3386UXTx+LKkPBmf8i8i4NmA==", null, "6a21904b-47e4-4b2f-bdbc-8ba3d4890ded" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "092e99ab-8858-4e95-a203-d9fb9e529060", "AQAAAAIAAYagAAAAEEVvLi77WS9QNPWOKZBs8xHrJF6OdpEOCS8/7bVYV2s3EoT4tDXgrWFKf5onpwoz4w==", null, "40e24632-720d-4043-8717-7fa2bcb0c5de" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79208a02-be92-42d7-a5c5-429fb73f8b23", "AQAAAAIAAYagAAAAECOojwBjP8uYaXl8ZZGZCl3WYH1A68x90x0Pw5Nt5jVOAts1dQCgz3YWVZr6379/uQ==", "7dddac65-e6fc-466b-9375-c5177aa3705f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31c98eca-a8be-4793-9245-d5ec9089904f", "AQAAAAIAAYagAAAAEGzehEmQPGWfDSscx4Qv8niVDDdjz7baWPcSwgQe2amhtrkxhjN0FrAwEIGAPyB7dg==", "21f7a87b-a986-4c25-90a6-a2a8230586ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9edc67b9-43f7-4d15-a260-28e2fff57896", "AQAAAAIAAYagAAAAEOFOpmOIkwUa3m2Y2hIOKkN/NQAUMQSHc2SY8HLxgEnLrZfyPfS4PWIUlvR2+hDIAQ==", "2de93841-5b68-4612-a4c5-94d1654169e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "621a1f12-4edf-490b-a761-8bf6ca3e02ae", "AQAAAAIAAYagAAAAEO2ViDNFxZPs5qEX7N39mr3uEY2XdE+UsIB3hRrTFeuj4MLF9X/X+uSCc3YOFvGbRQ==", "80c733aa-6c9a-43c3-82dd-09bb36e58924" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f748987-8306-45f3-b864-4e9ece1d6ced", "AQAAAAIAAYagAAAAEEELpVw6b6pl44zuXPSdkgceyUqpL2iDN/bBbYhMsQPeQ0AA8CBmvgUto+IT7yi3KQ==", "5154efc6-8f46-4f61-990c-1cb3ce109852" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "557dedd3-36f7-4129-ad7f-e1c6945ebae6", "AQAAAAIAAYagAAAAEMEca3CWtgBZrw44KhldR+ndgCg7o42/GmqPM0v4QRzwXGSAkmHEMamsmzVPFC/SLQ==", "751519f9-03e7-4a95-8e58-cd8166505940" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fa9c356-65ef-493b-b2bf-f2fb5d444779", "AQAAAAIAAYagAAAAEA+QfiyElPt586AyIe/1Ocjym3ON6jv97dKPTSHAqsYbP/OVCgyVJ41Q53XmJuO+Bg==", "04905f04-ed5d-4146-a670-35e4c8876895" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01013954-1d3f-47af-909c-7b6c8d7f24fe", "AQAAAAIAAYagAAAAEP+YtB3NRsnz4jO8xZi+DxydF/bgbjXkDeLfR1+c4WkLDztu6+z54ZqWGSyM6JbD/Q==", "21c400a2-1da6-4528-9883-1df4a01d52b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19099cd6-f8e3-49ef-875f-887765ad075a", "AQAAAAIAAYagAAAAEF8uywOyUXWsb+LANFimT+C4kRIel6NvbVdpv8JeBB8kkIptqmKuFBxkwyxSWU8C0g==", "bdd8bee2-94f3-4c6f-8199-677c3230ad92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf20aacd-a801-4e3f-8e99-acc11cb9edb4", "AQAAAAIAAYagAAAAEGk2zOXaHmps6DS9Sv365YosSewjo81HTaXOd2Hc45YFaw55c+4tuyFkXT23IwkLQg==", "ec7e33a1-30c5-4550-9010-02245c8ce6a2" });
        }
    }
}
