using Microsoft.EntityFrameworkCore.Migrations;

namespace hashmemes.Migrations
{
    public partial class updatingGroupAndAddingController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Groups",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Groups");
        }
    }
}
