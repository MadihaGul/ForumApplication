using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApplication.API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedTime", "Detail", "Title", "UpdatedTime" },
                values: new object[] { 1, new DateTime(2023, 10, 6, 15, 35, 19, 116, DateTimeKind.Utc).AddTicks(1175), "There is alot to learn about Sweden", "New to Sweden", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedTime", "Detail", "Title", "UpdatedTime" },
                values: new object[] { 2, new DateTime(2023, 10, 5, 15, 35, 19, 116, DateTimeKind.Utc).AddTicks(1180),
                    "No details available", "Looking for work", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedTime", "Detail", "Title", "UpdatedTime" },
                values: new object[] { 3, new DateTime(2023, 10, 7, 12, 35, 19, 116, DateTimeKind.Utc).AddTicks(1181), @"Computer Engineer with 4 years of experience in C#.net 
                    web application development but I am open to learn new skills.
                    I came to Sweden 5 years ago and focused on learning Swedish. 
                    I have done internship at a start-up company called Yoin Technologies where
                    I worked as a backend developer and worked with Azure among other things.
                    Marcus Melberg, the CTO, was my supervisor at Yoin. Marcus is my refernce
                    and you are welcome to contact him to get more information. I like to learn new things
                    and I am looking for new challenges to further develop my knowlegde and skills. 
                    I want to contribute in the field of IT and increase my competance through work.
                    I am a hard working and ambitious woman who needs a chance to grow professionally", "Bio Madiha Gul", null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedTime", "PostId", "Text", "UpdatedTime" },
                values: new object[] { 1, new DateTime(2023, 10, 6, 16, 35, 19, 116, DateTimeKind.Utc).AddTicks(1269), 1, "The most sustainable city in the world - Gothenburg", null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedTime", "PostId", "Text", "UpdatedTime" },
                values: new object[] { 2, new DateTime(2023, 10, 7, 13, 35, 19, 116, DateTimeKind.Utc).AddTicks(1270), 1, "I like it", null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedTime", "PostId", "Text", "UpdatedTime" },
                values: new object[] { 3, new DateTime(2023, 10, 7, 14, 35, 19, 116, DateTimeKind.Utc).AddTicks(1271), 3, "Good Luck", null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedTime", "PostId", "Text", "UpdatedTime" },
                values: new object[] { 4, new DateTime(2023, 10, 6, 16, 35, 19, 116, DateTimeKind.Utc).AddTicks(1272), 1, "Nice", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
