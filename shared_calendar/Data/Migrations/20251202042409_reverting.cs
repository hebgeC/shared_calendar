using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shared_calendar.Migrations
{
    /// <inheritdoc />
    public partial class reverting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "CalendarEvent",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "CalendarEvent",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTime",
                table: "CalendarEvent",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTime",
                table: "CalendarEvent",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
