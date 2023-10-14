using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightFireMoreTech5.Migrations
{
    /// <inheritdoc />
    public partial class fixForignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_office_service_windows_windowid",
                table: "office_service");

            migrationBuilder.DropForeignKey(
                name: "fk_window_offices_officeid",
                table: "window");

            migrationBuilder.DropForeignKey(
                name: "fk_window_service_window_windowid",
                table: "window_service");

            migrationBuilder.DropIndex(
                name: "ix_office_service_windowid",
                table: "office_service");

            migrationBuilder.DropColumn(
                name: "windowid",
                table: "office_service");

            migrationBuilder.AddColumn<long>(
                name: "windowid1",
                table: "window_service",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "officeid",
                table: "window",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "officeid1",
                table: "window",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "ix_window_service_windowid",
                table: "window_service",
                column: "windowid1");

            migrationBuilder.CreateIndex(
                name: "ix_window_officeid1",
                table: "window",
                column: "officeid1");

            migrationBuilder.AddForeignKey(
                name: "fk_window_offices_officeid",
                table: "window",
                column: "officeid",
                principalTable: "offices",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_window_offices_officeid1",
                table: "window",
                column: "officeid1",
                principalTable: "offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_window_service_window_windowid",
                table: "window_service",
                column: "windowid1",
                principalTable: "window",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_window_service_window_windowid1",
                table: "window_service",
                column: "windowid",
                principalTable: "window",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_window_offices_officeid",
                table: "window");

            migrationBuilder.DropForeignKey(
                name: "fk_window_offices_officeid1",
                table: "window");

            migrationBuilder.DropForeignKey(
                name: "fk_window_service_window_windowid",
                table: "window_service");

            migrationBuilder.DropForeignKey(
                name: "fk_window_service_window_windowid1",
                table: "window_service");

            migrationBuilder.DropIndex(
                name: "ix_window_service_windowid",
                table: "window_service");

            migrationBuilder.DropIndex(
                name: "ix_window_officeid1",
                table: "window");

            migrationBuilder.DropColumn(
                name: "windowid1",
                table: "window_service");

            migrationBuilder.DropColumn(
                name: "officeid1",
                table: "window");

            migrationBuilder.AlterColumn<long>(
                name: "officeid",
                table: "window",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "windowid",
                table: "office_service",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_office_service_windowid",
                table: "office_service",
                column: "windowid");

            migrationBuilder.AddForeignKey(
                name: "fk_office_service_windows_windowid",
                table: "office_service",
                column: "windowid",
                principalTable: "window",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_window_offices_officeid",
                table: "window",
                column: "officeid",
                principalTable: "offices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_window_service_window_windowid",
                table: "window_service",
                column: "windowid",
                principalTable: "window",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
