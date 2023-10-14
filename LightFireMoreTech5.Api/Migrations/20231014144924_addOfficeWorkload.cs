using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    /// <inheritdoc />
    public partial class addOfficeWorkload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "workload",
                table: "offices",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "workload",
                table: "offices");
        }
    }
}
