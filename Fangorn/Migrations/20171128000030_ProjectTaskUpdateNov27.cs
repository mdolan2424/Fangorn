using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tower.Migrations
{
    public partial class ProjectTaskUpdateNov27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Teams_AssignedTeamId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_ProjectTasks_ProjectTaskId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_AssignedTeamId",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_ProjectTaskId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "AssignedTeamId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "ProjectTaskId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ProjectTasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "ProjectTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "ProjectTasks");

            migrationBuilder.AddColumn<string>(
                name: "AssignedTeamId",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ProjectTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProjectTaskId",
                table: "ProjectTasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "ProjectTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AssignedTeamId",
                table: "ProjectTasks",
                column: "AssignedTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectTaskId",
                table: "ProjectTasks",
                column: "ProjectTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Teams_AssignedTeamId",
                table: "ProjectTasks",
                column: "AssignedTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_ProjectTasks_ProjectTaskId",
                table: "ProjectTasks",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
