using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    /// <inheritdoc />
    public partial class addService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_service", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "atm_service",
                columns: table => new
                {
                    atmid = table.Column<long>(type: "bigint", nullable: false),
                    serviceid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_atm_service", x => new { x.atmid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_atm_service_atms_atmid",
                        column: x => x.atmid,
                        principalTable: "atms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_atm_service_service_serviceid",
                        column: x => x.serviceid,
                        principalTable: "service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "office_service",
                columns: table => new
                {
                    officeid = table.Column<long>(type: "bigint", nullable: false),
                    serviceid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_office_service", x => new { x.officeid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_office_service_offices_officeid",
                        column: x => x.officeid,
                        principalTable: "offices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_office_service_service_serviceid",
                        column: x => x.serviceid,
                        principalTable: "service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_atm_service_serviceid",
                table: "atm_service",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_office_service_serviceid",
                table: "office_service",
                column: "serviceid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atm_service");

            migrationBuilder.DropTable(
                name: "office_service");

            migrationBuilder.DropTable(
                name: "service");
        }
    }
}
