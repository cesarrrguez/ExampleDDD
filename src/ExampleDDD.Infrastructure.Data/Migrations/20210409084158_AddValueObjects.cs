using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleDDD.Infrastructure.Data.Migrations
{
    public partial class AddValueObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                schema: "data",
                table: "UserEmails",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "data",
                table: "UserEmails",
                newName: "EmailAddress");
        }
    }
}
