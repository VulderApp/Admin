using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vulder.Admin.Infrastructure.Migrations
{
    public partial class UserSchoolList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schools");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolBaseUrl = table.Column<string>(type: "text", nullable: true),
                    SchoolTimetableUrl = table.Column<string>(type: "text", nullable: true),
                    User = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_Users_User",
                        column: x => x.User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schools_User",
                table: "Schools",
                column: "User");
        }
    }
}
