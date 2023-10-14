using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    /// <inheritdoc />
    public partial class addWindowTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_atm_service_atms_atmid",
                table: "atm_service");

            migrationBuilder.DropForeignKey(
                name: "fk_office_service_offices_officeid",
                table: "office_service");

            migrationBuilder.AddColumn<int>(
                name: "averagewaittime",
                table: "service",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "officeid1",
                table: "office_service",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "windowid",
                table: "office_service",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "atmid1",
                table: "atm_service",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "window",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    busytime = table.Column<int>(type: "integer", nullable: false),
                    officeid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_window", x => x.id);
                    table.ForeignKey(
                        name: "fk_window_offices_officeid",
                        column: x => x.officeid,
                        principalTable: "offices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "window_service",
                columns: table => new
                {
                    windowid = table.Column<long>(type: "bigint", nullable: false),
                    serviceid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_window_service", x => new { x.windowid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_window_service_service_serviceid",
                        column: x => x.serviceid,
                        principalTable: "service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_window_service_window_windowid",
                        column: x => x.windowid,
                        principalTable: "window",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_office_service_officeid",
                table: "office_service",
                column: "officeid1");

            migrationBuilder.CreateIndex(
                name: "ix_office_service_windowid",
                table: "office_service",
                column: "windowid");

            migrationBuilder.CreateIndex(
                name: "ix_atm_service_atmid",
                table: "atm_service",
                column: "atmid1");

            migrationBuilder.CreateIndex(
                name: "ix_window_officeid",
                table: "window",
                column: "officeid");

            migrationBuilder.CreateIndex(
                name: "ix_window_service_serviceid",
                table: "window_service",
                column: "serviceid");

            migrationBuilder.AddForeignKey(
                name: "fk_atm_service_atms_atmid",
                table: "atm_service",
                column: "atmid1",
                principalTable: "atms",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_atm_service_atms_atmid1",
                table: "atm_service",
                column: "atmid",
                principalTable: "atms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_office_service_offices_officeid",
                table: "office_service",
                column: "officeid1",
                principalTable: "offices",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_office_service_offices_officeid1",
                table: "office_service",
                column: "officeid",
                principalTable: "offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_office_service_windows_windowid",
                table: "office_service",
                column: "windowid",
                principalTable: "window",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_atm_service_atms_atmid",
                table: "atm_service");

            migrationBuilder.DropForeignKey(
                name: "fk_atm_service_atms_atmid1",
                table: "atm_service");

            migrationBuilder.DropForeignKey(
                name: "fk_office_service_offices_officeid",
                table: "office_service");

            migrationBuilder.DropForeignKey(
                name: "fk_office_service_offices_officeid1",
                table: "office_service");

            migrationBuilder.DropForeignKey(
                name: "fk_office_service_windows_windowid",
                table: "office_service");

            migrationBuilder.DropTable(
                name: "window_service");

            migrationBuilder.DropTable(
                name: "window");

            migrationBuilder.DropIndex(
                name: "ix_office_service_officeid",
                table: "office_service");

            migrationBuilder.DropIndex(
                name: "ix_office_service_windowid",
                table: "office_service");

            migrationBuilder.DropIndex(
                name: "ix_atm_service_atmid",
                table: "atm_service");

            migrationBuilder.DropColumn(
                name: "averagewaittime",
                table: "service");

            migrationBuilder.DropColumn(
                name: "officeid1",
                table: "office_service");

            migrationBuilder.DropColumn(
                name: "windowid",
                table: "office_service");

            migrationBuilder.DropColumn(
                name: "atmid1",
                table: "atm_service");

            migrationBuilder.AddForeignKey(
                name: "fk_atm_service_atms_atmid",
                table: "atm_service",
                column: "atmid",
                principalTable: "atms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_office_service_offices_officeid",
                table: "office_service",
                column: "officeid",
                principalTable: "offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
