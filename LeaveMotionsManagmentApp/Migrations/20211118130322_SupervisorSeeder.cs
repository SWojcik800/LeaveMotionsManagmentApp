using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveMotionsManagmentApp.Migrations
{
    public partial class SupervisorSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                column: "ConcurrencyStamp",
                value: "59373f6c-f198-46dd-972c-cf813bf05424");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce929b1c-01df-4073-a711-c501b68b96f4", "8b1280d2-20e6-4464-8a6c-46ae41930e9b", "Supervisor", "SUPERVISOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "59373f6c-f198-46dd-972c-cf813bf05424", 0, "88c9b4fe-1413-4131-bc69-d2d4239251f9", "user@email.com", true, false, null, null, "USER@EMAIL.COM", "AQAAAAEAACcQAAAAEFfXwdR5Qu/k6vGRx9AlYAtP1aKlUM0oMdqr1k3eiv10DfW8iju0HH2M2dL73se+Qg==", null, false, "7479774d-3283-48ad-9a0a-8437b391698b", false, "user@email.com" },
                    { "8b1280d2-20e6-4464-8a6c-46ae41930e9b", 0, "85837ebb-3603-4e6b-bca9-97a77f82be3a", "supervisor@email.com", true, false, null, null, "SUPERVISOR@EMAIL.COM", "AQAAAAEAACcQAAAAEHY+n2N0GHHxtevW3/C6RxU/l0+q/nARkBa/ZhMau0Q/ZxaQFB8uYP8SbgoinyrkIw==", null, false, "3a30367d-57cd-4d6e-9cc5-7fdb234f0298", false, "supervisor@email.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "59373f6c-f198-46dd-972c-cf813bf05424" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ce929b1c-01df-4073-a711-c501b68b96f4", "8b1280d2-20e6-4464-8a6c-46ae41930e9b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "59373f6c-f198-46dd-972c-cf813bf05424" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce929b1c-01df-4073-a711-c501b68b96f4", "8b1280d2-20e6-4464-8a6c-46ae41930e9b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce929b1c-01df-4073-a711-c501b68b96f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59373f6c-f198-46dd-972c-cf813bf05424");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1280d2-20e6-4464-8a6c-46ae41930e9b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                column: "ConcurrencyStamp",
                value: "341743f0-asd2–42de-afbf-59kmkkmk72cf6");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "79774c29-d38a-402f-9fbb-178d5941ec0a", "user@email.com", true, false, null, null, "USER@EMAIL.COM", "AQAAAAEAACcQAAAAEDgZxSRV1/QBVqj4qYkVkKcAjunMTQtJetLe1KPjUbdo6YpgnS8N/0K5fVwFfDNqcw==", null, false, "f99f28c6-e651-488b-8c40-4552d7c53faa", false, "user@email.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });
        }
    }
}
