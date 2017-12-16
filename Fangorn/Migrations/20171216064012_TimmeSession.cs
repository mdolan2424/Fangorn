using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tower.Migrations
{
    public partial class TimmeSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PausedMinutes",
                table: "TimeLog");

            migrationBuilder.AddColumn<DateTime>(
                name: "ContinueTime",
                table: "TimeLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TimeSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    TimeLogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSessions_TimeLog_TimeLogId",
                        column: x => x.TimeLogId,
                        principalTable: "TimeLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSessions_TimeLogId",
                table: "TimeSessions",
                column: "TimeLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSessions");

            migrationBuilder.DropColumn(
                name: "ContinueTime",
                table: "TimeLog");

            migrationBuilder.AddColumn<int>(
                name: "PausedMinutes",
                table: "TimeLog",
                nullable: false,
                defaultValue: 0);
        }
    }
}
