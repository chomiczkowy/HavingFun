using Microsoft.EntityFrameworkCore.Migrations;

namespace HavingFun.EFDAL.Migrations
{
    public partial class AddedIsActivatedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                schema: "schUsers",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivated",
                schema: "schUsers",
                table: "Users");
        }
    }
}
