using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalCmsSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class viewcheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRole_AppUser_UserId",
                table: "AppUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_AppUser_AppUserId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AppUser_AppUserId",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AppUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AppUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AppUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

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
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "CreatedAt", "Email", "FullName", "ImagePath", "Password", "Phone", "UpdatedAt", "Username" },
                values: new object[] { "New York", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe", "path/to/image1.jpg", "password123", "123-456-7890", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "CreatedAt", "Email", "FullName", "ImagePath", "Password", "Phone", "UpdatedAt", "Username" },
                values: new object[] { "Los Angeles", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith", "path/to/image2.jpg", "password456", "098-765-4321", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "janesmith" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "CreatedAt", "Email", "FullName", "ImagePath", "Password", "Phone", "UpdatedAt", "Username" },
                values: new object[] { "Chicago", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@example.com", "Alice Johnson", "path/to/image3.jpg", "password789", "555-666-7777", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alicejohnson" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "City", "CreatedAt", "Email", "FullName", "ImagePath", "Password", "Phone", "UpdatedAt", "Username" },
                values: new object[] { "Houston", new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob Brown", "path/to/image4.jpg", "password101", "222-333-4444", new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bobbrown" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "City", "CreatedAt", "Email", "FullName", "ImagePath", "Password", "Phone", "UpdatedAt", "Username" },
                values: new object[] { "Phoenix", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.davis@example.com", "Charlie Davis", "path/to/image5.jpg", "password202", "999-888-7777", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "charliedavis" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Categories", "Content", "Tag", "Title" },
                values: new object[] { "[\"Health\",\"Cardiology\",\"Wellness\"]", "An introductory guide to maintaining a healthy heart.", "Health", "Heart Health 101" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Categories", "Content", "Tag", "Title" },
                values: new object[] { "[\"Science\",\"Neurology\",\"Research\"]", "Exploring recent breakthroughs in neuroscientific research.", "Science", "Advancements in Neurology" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Categories", "Content", "Tag", "Title" },
                values: new object[] { "[\"Nutrition\",\"Gastroenterology\",\"Diet\"]", "Dietary habits to support your gastrointestinal system.", "Nutrition", "Nutrition for Digestive Health" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Categories", "Content", "Tag", "Title" },
                values: new object[] { "[\"Orthopedics\",\"Innovation\",\"Care\"]", "The future of musculoskeletal treatments and patient care.", "Orthopedics", "Orthopedic Innovations" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Categories", "Content", "Tag", "Title" },
                values: new object[] { "[\"Dermatology\",\"Skincare\",\"Lifestyle\"]", "Personalized skincare approaches for every stage of life.", "Dermatology", "Skincare Routines for All Ages" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRole_AppUsers_UserId",
                table: "AppUserRole",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_AppUsers_AppUserId",
                table: "BlogComments",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AppUsers_AppUserId",
                table: "Blogs",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRole_AppUsers_UserId",
                table: "AppUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_AppUsers_AppUserId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AppUsers_AppUserId",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "AppUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "Id");

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
                columns: new[] { "City", "CreatedAt", "FullName", "ImagePath", "UpdatedAt" },
                values: new object[] { "CityOne", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7979), "User One", "path/to/user1.jpg", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7980) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "CreatedAt", "FullName", "ImagePath", "UpdatedAt" },
                values: new object[] { "CityTwo", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7981), "User Two", "path/to/user2.jpg", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7981) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "CreatedAt", "FullName", "ImagePath", "UpdatedAt" },
                values: new object[] { "CityThree", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7982), "User Three", "path/to/user3.jpg", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7982) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "City", "CreatedAt", "FullName", "ImagePath", "UpdatedAt" },
                values: new object[] { "CityFour", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7983), "User Four", "path/to/user4.jpg", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7983) });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "City", "CreatedAt", "FullName", "ImagePath", "UpdatedAt" },
                values: new object[] { "CityFive", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7984), "User Five", "path/to/user5.jpg", new DateTime(2024, 3, 16, 18, 31, 34, 941, DateTimeKind.Utc).AddTicks(7984) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Tag", "Title" },
                values: new object[] { "This is the content of the first blog post.", "General", "First Blog Title" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Tag", "Title" },
                values: new object[] { "This is the content of the second blog post.", "Health", "Second Blog Title" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "Tag", "Title" },
                values: new object[] { "This is the content of the third blog post.", "Update", "Third Blog Title" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Content", "Tag", "Title" },
                values: new object[] { "This is the content of the fourth blog post.", "News", "Fourth Blog Title" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Content", "Tag", "Title" },
                values: new object[] { "This is the content of the fifth blog post.", "General", "Fifth Blog Title" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRole_AppUser_UserId",
                table: "AppUserRole",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_AppUser_AppUserId",
                table: "BlogComments",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AppUser_AppUserId",
                table: "Blogs",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
