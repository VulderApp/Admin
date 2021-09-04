using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vulder.Admin.Infrastructure.Migrations
{
    public partial class SchoolRequestFormCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid[]>(
                name: "SchoolFormRequestCollection",
                table: "Users",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SchoolForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequesterId = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolName = table.Column<string>(type: "text", nullable: false),
                    TimetableUrl = table.Column<string>(type: "text", nullable: false),
                    SchoolUrl = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ApprovedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ApprovedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolForms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolForms");

            migrationBuilder.DropColumn(
                name: "SchoolFormRequestCollection",
                table: "Users");
        }
    }
}
