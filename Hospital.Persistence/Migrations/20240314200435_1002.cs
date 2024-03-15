using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalCmsSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Ahmet");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Mehmet");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Şevval");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Uğur");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Hıdır");

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

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Ahmet");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Şevval");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Mehmet");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Uğur");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Hıdır");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "A");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "B");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "C");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "D");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "E");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Admins");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5117), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5121) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5122), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5122) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5123), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5124) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5125), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5125) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5126), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5126) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5164), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5166), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5167), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5168) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5168), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5170), new DateTime(2024, 3, 14, 18, 33, 26, 526, DateTimeKind.Utc).AddTicks(5170) });
        }
    }
}
