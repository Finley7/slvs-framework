using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLVS.Migrations
{
    /// <inheritdoc />
    public partial class UserAndUserGroupSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Default user group", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "Lettercode", "Password" },
                values: new object[] { 1, new DateTime(2023, 7, 11, 20, 54, 56, 20, DateTimeKind.Local).AddTicks(7433), "finley@siebertmedia.nl", "SIEFA", "$2a$11$D.B8lN5GS0bF4./.0QwsZO1H7g650QFTBb/ppn0Y0U15IcYCpxkdO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
