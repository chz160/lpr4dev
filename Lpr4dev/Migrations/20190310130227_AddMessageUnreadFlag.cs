using Microsoft.EntityFrameworkCore.Migrations;

namespace Lpr4dev.Migrations
{
    public partial class AddMessageUnreadFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUnread",
                table: "Messages",
                nullable: false,
                defaultValue: false);
        }
    }
}
