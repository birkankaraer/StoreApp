using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "035bdd1a-45b2-4408-b621-ea2354d9590b", "c404389c-4e52-4737-8258-e0f043ee4cbb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08bc24ea-de0e-4dff-b4be-4dc59063cfee", "23ee0522-4aa0-49ec-a3c5-43ce7dd0dc95", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8f58f0e-39e3-42c8-a786-7e3836acce22", "2349c5b5-87f3-483b-82cd-5b1bdcaa53ca", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "035bdd1a-45b2-4408-b621-ea2354d9590b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08bc24ea-de0e-4dff-b4be-4dc59063cfee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f58f0e-39e3-42c8-a786-7e3836acce22");
        }
    }
}
