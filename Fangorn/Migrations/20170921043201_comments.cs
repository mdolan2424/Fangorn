using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tower.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Contact_contactId",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "ServiceOrderComment");

            migrationBuilder.RenameColumn(
                name: "contactId",
                table: "ServiceOrders",
                newName: "ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_contactId",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_ContactId");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentorId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ServiceOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_CommentorId",
                        column: x => x.CommentorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentorId",
                table: "Comment",
                column: "CommentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ServiceOrderId",
                table: "Comment",
                column: "ServiceOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Contact_ContactId",
                table: "ServiceOrders",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Contact_ContactId",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "ServiceOrders",
                newName: "contactId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_ContactId",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_contactId");

            migrationBuilder.CreateTable(
                name: "ServiceOrderComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentorId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ServiceOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrderComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrderComment_AspNetUsers_CommentorId",
                        column: x => x.CommentorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceOrderComment_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderComment_CommentorId",
                table: "ServiceOrderComment",
                column: "CommentorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderComment_ServiceOrderId",
                table: "ServiceOrderComment",
                column: "ServiceOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Contact_contactId",
                table: "ServiceOrders",
                column: "contactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
