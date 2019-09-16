using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HavingFun.EFDAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "schUsers");

            migrationBuilder.CreateTable(
                name: "Claims",
                schema: "schUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "schUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "schUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 256, nullable: true),
                    LastName = table.Column<string>(maxLength: 256, nullable: true),
                    Username = table.Column<string>(maxLength: 256, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "schUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => new { x.ClaimId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserClaims_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalSchema: "schUsers",
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "schUsers",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "schUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "schUsers",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "schUsers",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "schUsers",
                table: "Claims",
                columns: new[] { "Id", "Type", "Value" },
                values: new object[] { 1, "CanSeeUsersList", "Allow" });

            migrationBuilder.InsertData(
                schema: "schUsers",
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "IsActivated", "LastName", "PasswordHash", "Username" },
                values: new object[] { 1, "karolas-borys@wp.pl", "Karol", true, "LatkaAdmin", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "KarolAdmin" });

            migrationBuilder.InsertData(
                schema: "schUsers",
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "IsActivated", "LastName", "PasswordHash", "Username" },
                values: new object[] { 2, "karolas-borys2@wp.pl", "Karol", true, "LatkaRegular", "effcc54ba75fb84cca1aadb6cae302e84c29dcb550e6e19e99c4916b89c69e0b", "Karol" });

            migrationBuilder.InsertData(
                schema: "schUsers",
                table: "UserClaims",
                columns: new[] { "ClaimId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "schUsers",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "schUsers",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "schUsers");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "schUsers");

            migrationBuilder.DropTable(
                name: "Claims",
                schema: "schUsers");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "schUsers");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "schUsers");
        }
    }
}
