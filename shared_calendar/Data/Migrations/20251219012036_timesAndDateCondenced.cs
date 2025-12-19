using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shared_calendar.Migrations
{
    /// <inheritdoc />
    public partial class timesAndDateCondenced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "CalendarEvent");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "CalendarEvent",
                newName: "StartDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "CalendarEvent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "CalendarEvent");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "CalendarEvent",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "CalendarEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "CalendarEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
