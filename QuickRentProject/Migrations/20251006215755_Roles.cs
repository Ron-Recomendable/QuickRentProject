using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRentProject.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d29d31a-5e06-4178-b2f1-93b4fdce73a3", "AQAAAAIAAYagAAAAEH6iMhhLQbdMnpcXRIQpI7lONuYlUacmQaQGzvh1ICV+c6S9tNfRS5i/oXWcrl0Y6Q==", "d6d2fdfb-b1a4-4b7d-8156-5f13fa5747e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7eda1772-d563-45db-99d3-49487c177c0d", "AQAAAAIAAYagAAAAEEY0Egy71Dssx81OzxY2imdNdPM37xrsFFzHHSZZwLBQVVYqob2D6YcUv4k4mvfyHQ==", "d8501f8b-c205-41ca-9233-c88f6778df0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10af8399-dbdf-49c6-b62c-ce844cfebdba", "AQAAAAIAAYagAAAAEJE5oV+zaljW7qpE70XUe+AoJPIbzmI8SZFjM4UUnVwH8v99HUXmWkOu+7eyN311Ig==", "c7f6d348-7eb8-4d18-a08a-2652346ecda1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f5f21bd-02d5-46bd-a3a9-91b7d3d331a3", "AQAAAAIAAYagAAAAEEveIxrWBD/Bzaz6pBOfK36u10ppU3P9U13N8VQh/g/8ne5G8VzZ487Uz9sHu03GrA==", "d336d353-f783-40cc-8cf6-c7de3200856f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ca824d3-5631-400e-89a4-601ff6577092", "AQAAAAIAAYagAAAAEFk4SC2Z2d5SgsU4iurMeU6dtWyvPBCk8W039hwtHz7igHqk22KrchGWQRR6mGY8AA==", "4cebee61-64b2-4fe7-b7e6-97b5b35593f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f63c33c6-73d5-460e-85b7-542335ec2e8d", "AQAAAAIAAYagAAAAENzKHLJiygJRp4cLNnwXRJn4fX5KBfxPJBwbRnhzxSPs8yw/w3hU43wVd9CJ9hyjkA==", "eab9c1fe-43e1-4c29-a813-f9e7e071e60e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb678577-d6a7-4957-8486-1cb036d9a7db", "AQAAAAIAAYagAAAAENc8HBFZmag8lJqqBJOwv8cnjikRZjNJoYD2wtWFY9vaN3HXtaGVx7185t6OVzOp8g==", "ee6bf73a-ccbd-4c50-a18b-6c531febc323" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1907e474-da9f-45f8-ba6e-65ed12aa2739", "AQAAAAIAAYagAAAAEBXn43Y0MY8bKNQIswodUCiQF3q/Z3idGHPjC/Z+15mWOWYCUmWEDq03p3mZrZOdPQ==", "a28b1fb6-e743-4141-9fe4-13a0e022b723" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8f62e06-30b7-409d-afcb-be4bc8da0ffa", "AQAAAAIAAYagAAAAEOvwsHqm7yjL4O6wV8g6xKpVEBHHfF7y0zJ7ORJXlbbRQn3FdSLefT0R3i59VvXCug==", "f13683c7-a2b7-4f78-80ce-962cc60f47f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e98e23fd-192b-47e7-834e-a0fd72b02941", "AQAAAAIAAYagAAAAEOlWgC7shIp7g9ZgiFJfnWVlRx1OvxHWmljsC+YAklQjAq7i315umGoYfcHnXuSDcA==", "cf7d4bd1-d0c5-4091-930b-9a0ce1c26cac" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d73da51-1f04-4e46-ac6e-f379643d7d20", "AQAAAAIAAYagAAAAEK01uXVBHyqLZj9CbIUIv86zcL+8gZoNnl7ZJDAx5QAJFNVNoUEFyln3UBW99dBR1g==", "70dcb800-6a1c-48dc-be44-9c20e80e1237" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39d5c093-515b-44e8-836a-65b7da47ea01", "AQAAAAIAAYagAAAAENVLwWYBIEmi4+nwlSTyyghKkmr4tpLRmDDsGpLVXdvJOgceptNCWnlgG3+NOnJwVQ==", "a3087956-1cd0-476b-9382-bfef89f0fddc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "101927d1-ed0f-4121-b222-053586c4247d", "AQAAAAIAAYagAAAAEFxJL3h0SlG/RTp4x1g4d0g1SbYVcL5Q254N9MsJKUYKaMSy/CGRW5udzVB2DS33Yw==", "57e1daee-0fd8-40cf-af45-187b8791d96e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33c45fde-1ddd-4f6d-a8f1-e25d43e9d9db", "AQAAAAIAAYagAAAAEByB25Ej21EmgHxUrSHN/LHxW/0tJGaueoffdiuzaIrTyQTpJrhe84xQjf8r8SvBkw==", "770646a8-bf06-49eb-9844-b64e95c68770" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53c65f7b-b10f-4bbd-9f2c-15777fe57017", "AQAAAAIAAYagAAAAECmgPdmTZNsslp5ZAu5Vb+4478WfkmWlRJYXGGNAPCugaS0PFddPZLQ5E8TXiGTqLA==", "c373cdcd-13f0-455a-9472-40e6d2c11354" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a10c0a2-d586-45c4-b362-35eda2a96c8f", "AQAAAAIAAYagAAAAEIBdPNdS0/Nq06jKJpG7nzQ33LmqO6nRUa1MCVxuU1//arb4TyGtpsBeXwnOqNaNMw==", "ebdf7e7b-9f48-4383-a2a5-f01c715c9fca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff341ba3-304f-4681-904f-f0002f10632b", "AQAAAAIAAYagAAAAEIVHAFSUnKUG2Wtno5GroG0dR49Vou5mb+c76nI7DI5OSYTotu3AJhP8QA3kmJXPcg==", "43c7f6b9-0eec-4677-8e5d-87e31e64ca21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf4e8984-910e-4736-8a5a-59c9c492ea61", "AQAAAAIAAYagAAAAEHzsxYzLbTDiREgHGprrRTZ8pgdmXfRnqXUh9uZ/FX7pVz/k+f8pmPEQ2rY1LAVMgg==", "bf7b2fde-7492-4778-9eb5-5b0fbb3068b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84599080-192f-4dfb-a723-5b83be1697fb", "AQAAAAIAAYagAAAAEF+fVkGLF+kTGMmzuy9SitxxiAuV5+LHe4+u3Jwqws3386UXTx+LKkPBmf8i8i4NmA==", "6a21904b-47e4-4b2f-bdbc-8ba3d4890ded" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "092e99ab-8858-4e95-a203-d9fb9e529060", "AQAAAAIAAYagAAAAEEVvLi77WS9QNPWOKZBs8xHrJF6OdpEOCS8/7bVYV2s3EoT4tDXgrWFKf5onpwoz4w==", "40e24632-720d-4043-8717-7fa2bcb0c5de" });
        }
    }
}
