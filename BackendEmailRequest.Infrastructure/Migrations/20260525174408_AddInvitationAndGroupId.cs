using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEmailRequest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInvitationAndGroupId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                schema: "email",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                schema: "email",
                newName: "EmailRequests",
                newSchema: "email");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                schema: "email",
                table: "EmailRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InvitationId",
                schema: "email",
                table: "EmailRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailRequests",
                schema: "email",
                table: "EmailRequests",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailRequests",
                schema: "email",
                table: "EmailRequests");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "email",
                table: "EmailRequests");

            migrationBuilder.DropColumn(
                name: "InvitationId",
                schema: "email",
                table: "EmailRequests");

            migrationBuilder.RenameTable(
                name: "EmailRequests",
                schema: "email",
                newName: "Groups",
                newSchema: "email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                schema: "email",
                table: "Groups",
                column: "Id");
        }
    }
}
