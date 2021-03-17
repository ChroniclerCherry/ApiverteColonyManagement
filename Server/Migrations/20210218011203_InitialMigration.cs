using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 679, DateTimeKind.Local).AddTicks(8048)),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 683, DateTimeKind.Local).AddTicks(5382)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Host",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 691, DateTimeKind.Local).AddTicks(970)),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 691, DateTimeKind.Local).AddTicks(1365)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Host", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colony",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 685, DateTimeKind.Local).AddTicks(7153)),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 685, DateTimeKind.Local).AddTicks(7561)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    HostId = table.Column<Guid>(type: "uuid", nullable: false),
                    AreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    HiveNumber = table.Column<int>(type: "integer", nullable: false),
                    ColonyNumber = table.Column<string>(type: "text", nullable: true),
                    ColonySource = table.Column<string>(type: "text", nullable: true),
                    QueenType = table.Column<string>(type: "text", nullable: true),
                    GeneticBreed = table.Column<string>(type: "text", nullable: true),
                    InstallationType = table.Column<string>(type: "text", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    InstallDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HiveType = table.Column<string>(type: "text", nullable: true),
                    BroodChamberType = table.Column<string>(type: "text", nullable: true),
                    QueenExclude = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colony", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colony_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colony_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colony_AreaId",
                table: "Colony",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Colony_HostId",
                table: "Colony",
                column: "HostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colony");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Host");
        }
    }
}
