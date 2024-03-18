using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalCmsSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "Blogs",
                newName: "Tags");

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

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tags",
                value: "[\"Health\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tags",
                value: "[\"Science\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tags",
                value: "[\"Nutrition\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tags",
                value: "[\"Orthopedics\"]");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Tags",
                value: "[\"Dermatology\"]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "Blogs",
                newName: "Tag");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8007), new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8008) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8008), new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8009) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8009), new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8010), new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8011) });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8011), new DateTime(2024, 3, 17, 13, 57, 27, 945, DateTimeKind.Utc).AddTicks(8012) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Tag",
                value: "Health");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Tag",
                value: "Science");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Tag",
                value: "Nutrition");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Tag",
                value: "Orthopedics");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Tag",
                value: "Dermatology");
        }
    }
}
