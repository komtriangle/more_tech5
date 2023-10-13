using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    /// <inheritdoc />
    public partial class officechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_offices_officeschedules_scheduleid",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "type",
                table: "office_schedule");

            migrationBuilder.RenameColumn(
                name: "shceduleid",
                table: "offices",
                newName: "legalentityshceduleid");

            migrationBuilder.RenameIndex(
                name: "ix_offices_shceduleid",
                table: "offices",
                newName: "ix_offices_legalentityshceduleid");

            migrationBuilder.AddColumn<long>(
                name: "individualshceduleid",
                table: "offices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "ix_offices_individualshceduleid",
                table: "offices",
                column: "individualshceduleid");

            migrationBuilder.AddForeignKey(
                name: "fk_offices_officeschedules_individualscheduleid",
                table: "offices",
                column: "individualshceduleid",
                principalTable: "office_schedule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_offices_officeschedules_legalentityscheduleid",
                table: "offices",
                column: "legalentityshceduleid",
                principalTable: "office_schedule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_offices_officeschedules_individualscheduleid",
                table: "offices");

            migrationBuilder.DropForeignKey(
                name: "fk_offices_officeschedules_legalentityscheduleid",
                table: "offices");

            migrationBuilder.DropIndex(
                name: "ix_offices_individualshceduleid",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "individualshceduleid",
                table: "offices");

            migrationBuilder.RenameColumn(
                name: "legalentityshceduleid",
                table: "offices",
                newName: "shceduleid");

            migrationBuilder.RenameIndex(
                name: "ix_offices_legalentityshceduleid",
                table: "offices",
                newName: "ix_offices_shceduleid");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "office_schedule",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_offices_officeschedules_scheduleid",
                table: "offices",
                column: "shceduleid",
                principalTable: "office_schedule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
