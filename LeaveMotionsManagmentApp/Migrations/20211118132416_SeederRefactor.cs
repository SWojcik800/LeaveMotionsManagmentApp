using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveMotionsManagmentApp.Migrations
{
    public partial class SeederRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59373f6c-f198-46dd-972c-cf813bf05424",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4ea0c2b-5ed7-425d-851f-bcfd938092b6", "AQAAAAEAACcQAAAAEAV5VrEFa9kUVRJRBkTJBZMduigaGIv1elujPkaF5kbXPigqSgvHrmpEuI5LdP/LSw==", "af4a23a8-8f08-4be3-aeb2-32acb2879341" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1280d2-20e6-4464-8a6c-46ae41930e9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b15de357-e5c2-4b0f-b281-74b4ada44020", "AQAAAAEAACcQAAAAEIaG3iDMHUbcDJrsmIIVDfkiZ7Qu0tNikY72Eh0KP3BIUJGvS7zfUSkAm0GPEo+thw==", "1e0a3725-6724-483a-90fb-56f7c40b9bb0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59373f6c-f198-46dd-972c-cf813bf05424",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e04ad77-4884-4506-a675-6dd92b94c636", "AQAAAAEAACcQAAAAEABnv/abUFqhIdWgLLpq5Yew6RKy3iI+Gm62CPSCq1wmYyqXhTPiAAcdXSb3d3JoKg==", "0eea492c-d38b-48a3-a17b-7b953a9f1c60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1280d2-20e6-4464-8a6c-46ae41930e9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b118dfc-a22b-4586-83df-9921b096afd3", "AQAAAAEAACcQAAAAEO0lFS4WRfugqvhZNFJChUGn28veWXUQgjmzLovJKqGPb+Ox9ovkbIN0vO+wEtdpRw==", "2c3d30bc-2628-4596-bac6-941c469e3f04" });
        }
    }
}
