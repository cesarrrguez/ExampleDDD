using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleDDD.Infrastructure.Data.Migrations
{
    public partial class AddUserState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                schema: "data",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                schema: "data",
                table: "Users");
        }
    }
}
