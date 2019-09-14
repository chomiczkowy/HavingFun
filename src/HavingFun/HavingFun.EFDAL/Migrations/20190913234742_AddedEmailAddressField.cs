using Microsoft.EntityFrameworkCore.Migrations;

namespace HavingFun.EFDAL.Migrations
{
    public partial class AddedEmailAddressField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                schema: "schUsers",
                table: "Users",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                schema: "schUsers",
                table: "Users");
        }
    }
}
