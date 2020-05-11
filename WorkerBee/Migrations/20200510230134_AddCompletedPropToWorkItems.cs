using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerBee.Migrations
{
    public partial class AddCompletedPropToWorkItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "WorkItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "WorkItems");
        }
    }
}
