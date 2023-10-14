using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "atms",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    allday = table.Column<bool>(type: "boolean", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    wheelchaircapability = table.Column<int>(type: "int", nullable: false),
                    wheelchairactivity = table.Column<int>(type: "int", nullable: false),
                    blindcapability = table.Column<int>(type: "int", nullable: false),
                    blindchairactivity = table.Column<int>(type: "int", nullable: false),
                    nfcbankcardscapability = table.Column<int>(type: "int", nullable: false),
                    nfcbankcardsactivity = table.Column<int>(type: "int", nullable: false),
                    qrreadcapability = table.Column<int>(type: "int", nullable: false),
                    qrreadactivity = table.Column<int>(type: "int", nullable: false),
                    supportusdcapability = table.Column<int>(type: "int", nullable: false),
                    supportusdactivity = table.Column<int>(type: "int", nullable: false),
                    supportchargerubcapability = table.Column<int>(type: "int", nullable: false),
                    supportchargerubactivity = table.Column<int>(type: "int", nullable: false),
                    supporteurcapability = table.Column<int>(type: "int", nullable: false),
                    supporteuractivity = table.Column<int>(type: "int", nullable: false),
                    supportrubcapability = table.Column<int>(type: "int", nullable: false),
                    supportrubactivity = table.Column<int>(type: "integer", nullable: false),
                    location = table.Column<Point>(type: "geography (Point,4326)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_atms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "office_schedule",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    availableonline = table.Column<bool>(type: "boolean", nullable: false),
                    onlinelink = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false),
                    averagewaittime = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_service", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "offices",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    metrostation = table.Column<string>(type: "text", nullable: true),
                    allday = table.Column<bool>(type: "bool", nullable: true),
                    rko = table.Column<bool>(type: "bool", nullable: true),
                    hasramp = table.Column<bool>(type: "bool", nullable: true),
                    kep = table.Column<long>(type: "bigint", nullable: true),
                    myoffice = table.Column<bool>(type: "bool", nullable: true),
                    officetype = table.Column<string>(type: "text", nullable: true),
                    salepointformat = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<Point>(type: "geography (Point,4326)", nullable: false),
                    individualshceduleid = table.Column<long>(type: "bigint", nullable: false),
                    legalentityshceduleid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offices", x => x.id);
                    table.ForeignKey(
                        name: "fk_offices_officeschedules_individualscheduleid",
                        column: x => x.individualshceduleid,
                        principalTable: "office_schedule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offices_officeschedules_legalentityscheduleid",
                        column: x => x.legalentityshceduleid,
                        principalTable: "office_schedule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "atm_service",
                columns: table => new
                {
                    atmid = table.Column<long>(type: "bigint", nullable: false),
                    serviceid = table.Column<long>(type: "bigint", nullable: false),
                    atmid1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_atm_service", x => new { x.atmid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_atm_service_atms_atmid",
                        column: x => x.atmid1,
                        principalTable: "atms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_atm_service_atms_atmid1",
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
                name: "office_service",
                columns: table => new
                {
                    officeid = table.Column<long>(type: "bigint", nullable: false),
                    serviceid = table.Column<long>(type: "bigint", nullable: false),
                    officeid1 = table.Column<long>(type: "bigint", nullable: true),
                    windowid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_office_service", x => new { x.officeid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_office_service_offices_officeid",
                        column: x => x.officeid1,
                        principalTable: "offices",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_office_service_offices_officeid1",
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
                    table.ForeignKey(
                        name: "fk_office_service_windows_windowid",
                        column: x => x.windowid,
                        principalTable: "window",
                        principalColumn: "id");
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
                name: "ix_atm_service_atmid",
                table: "atm_service",
                column: "atmid1");

            migrationBuilder.CreateIndex(
                name: "ix_atm_service_serviceid",
                table: "atm_service",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_atms_location",
                table: "atms",
                column: "location")
                .Annotation("Npgsql:IndexMethod", "GIST");

            migrationBuilder.CreateIndex(
                name: "ix_office_service_officeid",
                table: "office_service",
                column: "officeid1");

            migrationBuilder.CreateIndex(
                name: "ix_office_service_serviceid",
                table: "office_service",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_office_service_windowid",
                table: "office_service",
                column: "windowid");

            migrationBuilder.CreateIndex(
                name: "ix_offices_individualshceduleid",
                table: "offices",
                column: "individualshceduleid");

            migrationBuilder.CreateIndex(
                name: "ix_offices_legalentityshceduleid",
                table: "offices",
                column: "legalentityshceduleid");

            migrationBuilder.CreateIndex(
                name: "ix_offices_location",
                table: "offices",
                column: "location")
                .Annotation("Npgsql:IndexMethod", "GIST");

            migrationBuilder.CreateIndex(
                name: "ix_window_officeid",
                table: "window",
                column: "officeid");

            migrationBuilder.CreateIndex(
                name: "ix_window_service_serviceid",
                table: "window_service",
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
                name: "window_service");

            migrationBuilder.DropTable(
                name: "atms");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "window");

            migrationBuilder.DropTable(
                name: "offices");

            migrationBuilder.DropTable(
                name: "office_schedule");
        }
    }
}
