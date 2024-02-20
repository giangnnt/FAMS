using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FAMS.Migrations
{
    public partial class UserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "createdat", "dob", "email", "gender", "name", "Password", "phone", "roleid", "status", "updateat" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000012345"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FAMs@gmail.com", null, "Admin", "fams123", null, null, "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000012345"));
        }
    }
}
