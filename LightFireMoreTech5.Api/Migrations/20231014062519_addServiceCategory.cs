using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    /// <inheritdoc />
    public partial class addServiceCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "service",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "service");
        }
    }
}
