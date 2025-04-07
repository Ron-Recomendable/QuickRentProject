using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRentProject.Migrations
{
    /// <inheritdoc />
    public partial class FixedDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be32842c-181f-40e0-abfe-fe9f9d64e0ae", "AQAAAAIAAYagAAAAEPk2yefXazfNKMAYqWrcMvgGWfNckv4OmCebUIO1Ds6hq3lp/ohWXLp/gr0xQmDYpA==", "9f826bd8-9118-4eaf-b849-499999ab63c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96d31260-e442-4e44-a943-6416ae2b8145", "AQAAAAIAAYagAAAAEEtWkwy7zg29W90xi96tiq9lOPtPs8EVF9auosiwMBa7ShJKT5y+LvrW2+riqCxCiQ==", "b6607cab-8696-47cb-947b-ec8624b12806" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0269ed02-33d0-44b3-a023-1cb9d9505efc", "AQAAAAIAAYagAAAAEH0SjaK2omO6nBtDUMkJ6LvB/oiMIuq57lzbha9Pu60536JPyuYofatS5zs1oi5D2A==", "214c5880-8c07-4ddd-9fef-8390c7a2c35d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7db2983-fdf9-42ba-8f13-aa9d1424913e", "AQAAAAIAAYagAAAAEN5r/fTThlP79dnrClks72SgKmJHwqSH05cAjejql6DosrUqwN53QpefGI4NvGPAWw==", "04837a95-108d-4c7d-82cc-d41a8a996da9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de1452cf-04ab-4077-b3d2-4e1c52892a58", "AQAAAAIAAYagAAAAEOKGuQKJrgb0GLSf8LRL6nFX9krYjE53RSx+xVFgvT36eiaXtniC7uSDgO3pot0hHQ==", "78f6550a-b11a-4fc0-803c-8f81180a30b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9c160bd-02c4-4cff-8a64-4705557aa44e", "AQAAAAIAAYagAAAAENJaJQNX3l+RCgxAKgJv1HSEZeHFTB4zex9+db+BWi1z3nwtXYXkhCqIyODp8dkuYQ==", "96f0942d-0b43-4efd-9b83-59ff9c6ba9fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1c4971d-ccba-4f5d-a74b-66c0d55dacd4", "AQAAAAIAAYagAAAAEPczRG4U3NPIUQm4xT+ZZKE8xCV7YVoCrd92SZp2krtZ1x9+W94gVnnkxZKzf1rx6Q==", "db6a3937-78bc-4392-882a-5e6c6008756b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "758cc3a5-d4db-459d-bef5-d1ec7b7f9828", "AQAAAAIAAYagAAAAEO5lhlf29kEZVJ+9Hf9VgRQsulwnSQ4jGfTatW1k/x1eVeozLweXaU+FndQ4LhfhJA==", "aae9cb5e-d988-411b-970b-43ded561542c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f524cc1d-7b8e-44b2-8efd-d912e6f961d1", "AQAAAAIAAYagAAAAEIJL5Up59ieP5n954/dV3ScP28CBGnSkU789gKAo0JxIquO0oMMsTvGmFWM6VvMr8w==", "d2e36fc1-99eb-44c3-999f-6d41513fb52f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ba256f0-f2a6-4cb2-8a20-725bef507e10", "AQAAAAIAAYagAAAAEErJGjyLylptcVoNhmzD32isu8vzBgPHfl4W4kn3GqIKUvvdqgxjlT2xbFPZV3tH8w==", "1855e896-8998-47f7-a78f-f93cdbe0ed5a" });
        }
    }
}
