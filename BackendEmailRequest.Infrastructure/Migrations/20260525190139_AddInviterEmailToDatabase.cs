using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEmailRequest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInviterEmailToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderEmail",
                schema: "email",
                table: "EmailRequests",
                newName: "InviterEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InviterEmail",
                schema: "email",
                table: "EmailRequests",
                newName: "SenderEmail");
        }
    }
}
