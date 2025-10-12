using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRentProject.Migrations
{
    /// <inheritdoc />
    public partial class Registerform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
