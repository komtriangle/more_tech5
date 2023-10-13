using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    /// <inheritdoc />
    public partial class addOfficeInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "offices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "allday",
                table: "offices",
                type: "bool",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "hasramp",
                table: "offices",
                type: "bool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "metrostation",
                table: "offices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "myoffice",
                table: "offices",
                type: "bool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "offices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "officetype",
                table: "offices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "rko",
                table: "offices",
                type: "bool",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "salepointformat",
                table: "offices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "shceduleid",
                table: "offices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "office_schedule",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    mondaystart = table.Column<string>(type: "text", nullable: true),
                    mondayend = table.Column<string>(type: "text", nullable: true),
                    tuesdaystart = table.Column<string>(type: "text", nullable: true),
                    tuesdayend = table.Column<string>(type: "text", nullable: true),
                    wednesdaystart = table.Column<string>(type: "text", nullable: true),
                    wednesdayend = table.Column<string>(type: "text", nullable: true),
                    thursdaystart = table.Column<string>(type: "text", nullable: true),
                    thursdayend = table.Column<string>(type: "text", nullable: true),
                    fridaystart = table.Column<string>(type: "text", nullable: true),
                    fridayend = table.Column<string>(type: "text", nullable: true),
                    saturdaystart = table.Column<string>(type: "text", nullable: true),
                    saturdayend = table.Column<string>(type: "text", nullable: true),
                    sundaystart = table.Column<string>(type: "text", nullable: true),
                    sundayend = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_office_schedule", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_offices_shceduleid",
                table: "offices",
                column: "shceduleid");

            migrationBuilder.AddForeignKey(
                name: "fk_offices_officeschedules_scheduleid",
                table: "offices",
                column: "shceduleid",
                principalTable: "office_schedule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_offices_officeschedules_scheduleid",
                table: "offices");

            migrationBuilder.DropTable(
                name: "office_schedule");

            migrationBuilder.DropIndex(
                name: "ix_offices_shceduleid",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "address",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "allday",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "hasramp",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "metrostation",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "myoffice",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "name",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "officetype",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "rko",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "salepointformat",
                table: "offices");

            migrationBuilder.DropColumn(
                name: "shceduleid",
                table: "offices");
        }
    }
}
