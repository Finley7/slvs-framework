using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLVS.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionToUserGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionUserGroup_Permission_PermissionsId",
                table: "PermissionUserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionUserGroup_UserGroup_UserGroupsId",
                table: "PermissionUserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserGroup_UserGroup_UserGroupsId",
                table: "UserUserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserGroup_User_UsersId",
                table: "UserUserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.RenameTable(
                name: "UserGroup",
                newName: "UserGroups");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permissions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserGroups",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionUserGroup_Permissions_PermissionsId",
                table: "PermissionUserGroup",
                column: "PermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionUserGroup_UserGroups_UserGroupsId",
                table: "PermissionUserGroup",
                column: "UserGroupsId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserGroup_UserGroups_UserGroupsId",
                table: "UserUserGroup",
                column: "UserGroupsId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserGroup_Users_UsersId",
                table: "UserUserGroup",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionUserGroup_Permissions_PermissionsId",
                table: "PermissionUserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionUserGroup_UserGroups_UserGroupsId",
                table: "PermissionUserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserGroup_UserGroups_UserGroupsId",
                table: "UserUserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserGroup_Users_UsersId",
                table: "UserUserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserGroups");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "UserGroup");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permission");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionUserGroup_Permission_PermissionsId",
                table: "PermissionUserGroup",
                column: "PermissionsId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionUserGroup_UserGroup_UserGroupsId",
                table: "PermissionUserGroup",
                column: "UserGroupsId",
                principalTable: "UserGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserGroup_UserGroup_UserGroupsId",
                table: "UserUserGroup",
                column: "UserGroupsId",
                principalTable: "UserGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserGroup_User_UsersId",
                table: "UserUserGroup",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
