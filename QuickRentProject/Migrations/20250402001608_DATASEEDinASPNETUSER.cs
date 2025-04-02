using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickRentProject.Migrations
{
    /// <inheritdoc />
    public partial class DATASEEDinASPNETUSER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "4752950d-17df-4007-a731-966c51f54bb1", "pheobe@example.com", true, "Pheobe", "Townsend", false, null, "PHEOBE@EXAMPLE.COM", "PHOEBE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEOBViGb6Zl9uCJNCgRwEuJbitgVBPtlZgKN54u8160JYmIExaTRJhcQWID/D+deGA==", "531531413", false, "Admin", "d714d889-ac08-413b-84e4-773de1bbfbad", false, "Phoebe@example.com" },
                    { "2", 0, "750deb98-2cbe-41df-99bf-ed14538cebb6", "Rivka@example.com", true, "Rivka", "Simmons", false, null, "RIVKA@EXAMPLE.COM", "RIVKA@EXAMPLE.COM", "AQAAAAIAAYagAAAAEGDj5XXcuj+nUbJ6h531HouOBy2Z+EPx2ekfEISTVAUjpI7bNY30nLOeZBAi2Rf46w==", "4211614135", false, "Admin", "86f08c37-8ce1-447d-9d40-d72554c4cd4b", false, "Rivka@example.com" },
                    { "3", 0, "038bddcf-f5b2-4689-8ca7-d88359eac5ee", "Alianna@example.com", true, "Alianna", "Murray", false, null, "ALIANNA@EXAMPLE.COM", "ALIANNA@EXAMPLE.COM", "AQAAAAIAAYagAAAAECDFMto8cWSnpMETvQpF45CfaHkwDf7lGaaiCJNEg8NqHPk32dVgUdUYsT6CMFZOGw==", "7415135315", false, "Renter", "da5fea53-3dde-4b41-85e2-31b38fe32b12", false, "Alianna@example.com" },
                    { "4", 0, "24b088e5-bd17-43f4-9c55-5c3f337e9c5a", "Carolyn@example.com", true, "Carolyn", "Reese", false, null, "CAROLYN@EXAMPLE.COM", "CAROLYN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDZZigxUmexqrxIQDu3+rfUoON2odVomQ51KcgSpDQjJlfzeCqJt79D1pZWGaCsNyA==", "631641431", false, "Renter", "c95ad4eb-b8b4-4946-b6c8-541067882866", false, "Carolyn@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");
        }
    }
}
