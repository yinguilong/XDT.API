using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XDT.API.A.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Career = table.Column<string>(maxLength: 10, nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HeaderImg = table.Column<string>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    LoginAccount = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RegisteredDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Box",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Box_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoticeMessage",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    UserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NoticeMessage_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAdvice",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Level = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    UserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdvice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAdvice_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WareItem",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    FirstListenTime = table.Column<DateTime>(nullable: true),
                    ItemImage = table.Column<string>(maxLength: 500, nullable: true),
                    ItemName = table.Column<string>(maxLength: 50, nullable: true),
                    ItemSource = table.Column<byte>(nullable: false),
                    ItemType = table.Column<int>(nullable: false),
                    LastListenTime = table.Column<DateTime>(nullable: true),
                    ListenUrl = table.Column<string>(maxLength: 500, nullable: false),
                    OperatorID = table.Column<long>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    Trend = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WareItem_Users_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoxItem",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BoxID = table.Column<long>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    WareItemID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoxItem_Box_BoxID",
                        column: x => x.BoxID,
                        principalTable: "Box",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoxItem_WareItem_WareItemID",
                        column: x => x.WareItemID,
                        principalTable: "WareItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceItem",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActivityPrice = table.Column<decimal>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    WareItemID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PriceItem_WareItem_WareItemID",
                        column: x => x.WareItemID,
                        principalTable: "WareItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UrlHistoryItems",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(maxLength: 500, nullable: true),
                    WareItemID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlHistoryItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UrlHistoryItems_WareItem_WareItemID",
                        column: x => x.WareItemID,
                        principalTable: "WareItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WareItemDiscuss",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Additional = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Discuss = table.Column<string>(maxLength: 200, nullable: false),
                    ResId = table.Column<long>(nullable: true),
                    UserID = table.Column<long>(nullable: true),
                    WareItemID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareItemDiscuss", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WareItemDiscuss_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WareItemDiscuss_WareItem_WareItemID",
                        column: x => x.WareItemID,
                        principalTable: "WareItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Box_UserID",
                table: "Box",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BoxItem_BoxID",
                table: "BoxItem",
                column: "BoxID");

            migrationBuilder.CreateIndex(
                name: "IX_BoxItem_WareItemID",
                table: "BoxItem",
                column: "WareItemID");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeMessage_UserID",
                table: "NoticeMessage",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceItem_WareItemID",
                table: "PriceItem",
                column: "WareItemID");

            migrationBuilder.CreateIndex(
                name: "IX_UrlHistoryItems_WareItemID",
                table: "UrlHistoryItems",
                column: "WareItemID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvice_UserID",
                table: "UserAdvice",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WareItem_OperatorID",
                table: "WareItem",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_WareItemDiscuss_UserID",
                table: "WareItemDiscuss",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WareItemDiscuss_WareItemID",
                table: "WareItemDiscuss",
                column: "WareItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxItem");

            migrationBuilder.DropTable(
                name: "NoticeMessage");

            migrationBuilder.DropTable(
                name: "PriceItem");

            migrationBuilder.DropTable(
                name: "UrlHistoryItems");

            migrationBuilder.DropTable(
                name: "UserAdvice");

            migrationBuilder.DropTable(
                name: "WareItemDiscuss");

            migrationBuilder.DropTable(
                name: "Box");

            migrationBuilder.DropTable(
                name: "WareItem");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
