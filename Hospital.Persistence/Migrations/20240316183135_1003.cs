using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalCmsSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7949), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7951) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7952), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7953) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7953), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7954) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7954), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7955) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7955), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7956) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7979), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7980) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7981), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7981) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7982), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7982) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7983), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7983) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7984), new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7984) });

            migrationBuilder.InsertData(
                table: "DepartmentDetails",
                columns: new[] { "Id", "DepartmentId", "DescriptionLong", "DescriptionShort", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Long and detailed description of Cardiology, its services, and treatments.", "Short description of Cardiology", "About Cardiology" },
                    { 2, 2, "Long and detailed description of Neurology, its services, and treatments.", "Short description of Neurology", "About Neurology" },
                    { 3, 3, "Long and detailed description of Gastroenterology, its services, and treatments.", "Short description of Gastroenterology", "About Gastroenterology" },
                    { 4, 4, "Long and detailed description of Orthopedics, its services, and treatments.", "Short description of Orthopedics", "About Orthopedics" },
                    { 5, 5, "Long and detailed description of Dermatology, its services, and treatments.", "Short description of Dermatology", "About Dermatology" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DepartmentDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DepartmentDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DepartmentDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DepartmentDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DepartmentDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8069), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8071), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8071) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8072), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8072) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8073), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8073) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8074), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8101), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8103), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8106), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8106) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8107), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8107) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8107), new DateTime(2024, 3, 14, 20, 4, 35, 157, DateTimeKind.Utc).AddTicks(8108) });
        }
    }
}
