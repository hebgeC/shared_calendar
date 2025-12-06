using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shared_calendar.Migrations
{
    /// <inheritdoc />
    public partial class fixing_CalendarEvent_class_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CalendarEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EndTime",
                table: "CalendarEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartTime",
                table: "CalendarEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CalendarEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CalendarEvent");
        }
    }
}
