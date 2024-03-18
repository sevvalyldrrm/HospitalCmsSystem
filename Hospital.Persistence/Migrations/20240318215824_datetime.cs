using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalCmsSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class datetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3916), new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3917) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3918), new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3918) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3919), new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3919) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3920), new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3921), new DateTime(2024, 3, 18, 21, 58, 23, 849, DateTimeKind.Utc).AddTicks(3921) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 0, 58, 23, 849, DateTimeKind.Local).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 0, 58, 23, 849, DateTimeKind.Local).AddTicks(4080));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 0, 58, 23, 849, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 0, 58, 23, 849, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 0, 58, 23, 849, DateTimeKind.Local).AddTicks(4094));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(882), new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(884), new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(884) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(885), new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(886) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(886), new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(888), new DateTime(2024, 3, 17, 23, 19, 51, 787, DateTimeKind.Utc).AddTicks(888) });
        }
    }
}
