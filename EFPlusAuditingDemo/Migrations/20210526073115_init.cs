using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EFPlusAuditingDemo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditEntries",
                columns: table => new
                {
                    AuditEntryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EntitySetName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EntityTypeName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    StateName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEntries", x => x.AuditEntryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditEntryProperties",
                columns: table => new
                {
                    AuditEntryPropertyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuditEntryID = table.Column<int>(type: "integer", nullable: false),
                    PropertyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RelationName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NewValue = table.Column<string>(type: "text", nullable: true),
                    OldValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEntryProperties", x => x.AuditEntryPropertyID);
                    table.ForeignKey(
                        name: "FK_AuditEntryProperties_AuditEntries_AuditEntryID",
                        column: x => x.AuditEntryID,
                        principalTable: "AuditEntries",
                        principalColumn: "AuditEntryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditEntryProperties_AuditEntryID",
                table: "AuditEntryProperties",
                column: "AuditEntryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditEntryProperties");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AuditEntries");
        }
    }
}
