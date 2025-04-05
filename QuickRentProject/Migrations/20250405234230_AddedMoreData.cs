using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickRentProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "be32842c-181f-40e0-abfe-fe9f9d64e0ae", "AQAAAAIAAYagAAAAEPk2yefXazfNKMAYqWrcMvgGWfNckv4OmCebUIO1Ds6hq3lp/ohWXLp/gr0xQmDYpA==", "Renter", "9f826bd8-9118-4eaf-b849-499999ab63c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "0269ed02-33d0-44b3-a023-1cb9d9505efc", "AQAAAAIAAYagAAAAEH0SjaK2omO6nBtDUMkJ6LvB/oiMIuq57lzbha9Pu60536JPyuYofatS5zs1oi5D2A==", "Owner", "214c5880-8c07-4ddd-9fef-8390c7a2c35d" });

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10", 0, "96d31260-e442-4e44-a943-6416ae2b8145", "Jasmine@example.com", true, "Jasmine", "Everly", false, null, "JASMINE@EXAMPLE.COM", "JASMINE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEtWkwy7zg29W90xi96tiq9lOPtPs8EVF9auosiwMBa7ShJKT5y+LvrW2+riqCxCiQ==", "5556789012", false, "Owner", "b6607cab-8696-47cb-947b-ec8624b12806", false, "Jasmine@example.com" },
                    { "5", 0, "d9c160bd-02c4-4cff-8a64-4705557aa44e", "Damian@example.com", true, "Damian", "Fletcher", false, null, "DAMIAN@EXAMPLE.COM", "DAMIAN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENJaJQNX3l+RCgxAKgJv1HSEZeHFTB4zex9+db+BWi1z3nwtXYXkhCqIyODp8dkuYQ==", "5551234567", false, "Owner", "96f0942d-0b43-4efd-9b83-59ff9c6ba9fa", false, "Damian@example.com" },
                    { "6", 0, "b1c4971d-ccba-4f5d-a74b-66c0d55dacd4", "Elara@example.com", true, "Elara", "Whitmore", false, null, "ELARA@EXAMPLE.COM", "ELARA@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPczRG4U3NPIUQm4xT+ZZKE8xCV7YVoCrd92SZp2krtZ1x9+W94gVnnkxZKzf1rx6Q==", "5552345678", false, "Renter", "db6a3937-78bc-4392-882a-5e6c6008756b", false, "Elara@example.com" },
                    { "7", 0, "758cc3a5-d4db-459d-bef5-d1ec7b7f9828", "Gregory@example.com", true, "Gregory", "Holloway", false, null, "GREGORY@EXAMPLE.COM", "GREGORY@EXAMPLE.COM", "AQAAAAIAAYagAAAAEO5lhlf29kEZVJ+9Hf9VgRQsulwnSQ4jGfTatW1k/x1eVeozLweXaU+FndQ4LhfhJA==", "5553456789", false, "Renter", "aae9cb5e-d988-411b-970b-43ded561542c", false, "Gregory@example.com" },
                    { "8", 0, "f524cc1d-7b8e-44b2-8efd-d912e6f961d1", "Hazel@example.com", true, "Hazel", "Bridges", false, null, "HAZEL@EXAMPLE.COM", "HAZEL@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIJL5Up59ieP5n954/dV3ScP28CBGnSkU789gKAo0JxIquO0oMMsTvGmFWM6VvMr8w==", "5554567890", false, "Owner", "d2e36fc1-99eb-44c3-999f-6d41513fb52f", false, "Hazel@example.com" },
                    { "9", 0, "9ba256f0-f2a6-4cb2-8a20-725bef507e10", "Ivan@example.com", true, "Ivan", "Langley", false, null, "IVAN@EXAMPLE.COM", "IVAN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEErJGjyLylptcVoNhmzD32isu8vzBgPHfl4W4kn3GqIKUvvdqgxjlT2xbFPZV3tH8w==", "5555678901", false, "Renter", "1855e896-8998-47f7-a78f-f93cdbe0ed5a", false, "Ivan@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "4752950d-17df-4007-a731-966c51f54bb1", "AQAAAAIAAYagAAAAEEOBViGb6Zl9uCJNCgRwEuJbitgVBPtlZgKN54u8160JYmIExaTRJhcQWID/D+deGA==", "Admin", "d714d889-ac08-413b-84e4-773de1bbfbad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "750deb98-2cbe-41df-99bf-ed14538cebb6", "AQAAAAIAAYagAAAAEGDj5XXcuj+nUbJ6h531HouOBy2Z+EPx2ekfEISTVAUjpI7bNY30nLOeZBAi2Rf46w==", "Admin", "86f08c37-8ce1-447d-9d40-d72554c4cd4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "038bddcf-f5b2-4689-8ca7-d88359eac5ee", "AQAAAAIAAYagAAAAECDFMto8cWSnpMETvQpF45CfaHkwDf7lGaaiCJNEg8NqHPk32dVgUdUYsT6CMFZOGw==", "da5fea53-3dde-4b41-85e2-31b38fe32b12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24b088e5-bd17-43f4-9c55-5c3f337e9c5a", "AQAAAAIAAYagAAAAEDZZigxUmexqrxIQDu3+rfUoON2odVomQ51KcgSpDQjJlfzeCqJt79D1pZWGaCsNyA==", "c95ad4eb-b8b4-4946-b6c8-541067882866" });
        }
    }
}
