using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddInspectionPhotosAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Host",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 38, DateTimeKind.Local).AddTicks(4577),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 691, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Host",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 38, DateTimeKind.Local).AddTicks(4234),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 691, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Colony",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 36, DateTimeKind.Local).AddTicks(2740),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 685, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colony",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 36, DateTimeKind.Local).AddTicks(2390),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 685, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.AddColumn<string>(
                name: "Markings",
                table: "Colony",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Colony",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Area",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 34, DateTimeKind.Local).AddTicks(4356),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 683, DateTimeKind.Local).AddTicks(5382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Area",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 34, DateTimeKind.Local).AddTicks(4039),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 679, DateTimeKind.Local).AddTicks(8048));

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 19, DateTimeKind.Local).AddTicks(8831)),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 23, DateTimeKind.Local).AddTicks(2708)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Path = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 33, DateTimeKind.Local).AddTicks(1635)),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 33, DateTimeKind.Local).AddTicks(1998)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialInspection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 25, DateTimeKind.Local).AddTicks(2969)),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 25, DateTimeKind.Local).AddTicks(3334)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: true),
                    ColonyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Harvest = table.Column<string[]>(type: "text[]", nullable: true),
                    Feeds = table.Column<string[]>(type: "text[]", nullable: true),
                    Treatments = table.Column<string[]>(type: "text[]", nullable: true),
                    TreatmentDetails = table.Column<string[]>(type: "text[]", nullable: true),
                    Wintering = table.Column<string[]>(type: "text[]", nullable: true),
                    Growth = table.Column<string>(type: "text", nullable: true),
                    PhotoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialInspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialInspection_Colony_ColonyId",
                        column: x => x.ColonyId,
                        principalTable: "Colony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialInspection_Photo_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialInspection_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypicalInspection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 31, DateTimeKind.Local).AddTicks(449)),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 31, DateTimeKind.Local).AddTicks(807)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: true),
                    ColonyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Weather = table.Column<string[]>(type: "text[]", nullable: true),
                    Population = table.Column<string>(type: "text", nullable: true),
                    Mood = table.Column<string>(type: "text", nullable: true),
                    Fitness = table.Column<string>(type: "text", nullable: true),
                    BroodChambers = table.Column<int>(type: "integer", nullable: false),
                    HoneyChamber = table.Column<int>(type: "integer", nullable: false),
                    MouseGuard = table.Column<bool>(type: "boolean", nullable: false),
                    WaspGuard = table.Column<bool>(type: "boolean", nullable: false),
                    PollenCollector = table.Column<bool>(type: "boolean", nullable: false),
                    HiveBottom = table.Column<string>(type: "text", nullable: true),
                    Vents = table.Column<string>(type: "text", nullable: true),
                    Brood = table.Column<string>(type: "text", nullable: true),
                    Honey = table.Column<string>(type: "text", nullable: true),
                    BroodPattern = table.Column<string>(type: "text", nullable: true),
                    Issues = table.Column<string[]>(type: "text[]", nullable: true),
                    Growth = table.Column<string[]>(type: "text[]", nullable: true),
                    Seasonal = table.Column<string[]>(type: "text[]", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Cells = table.Column<string>(type: "text", nullable: true),
                    SwarmStatus = table.Column<string>(type: "text", nullable: true),
                    Excluder = table.Column<bool>(type: "boolean", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypicalInspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypicalInspection_Colony_ColonyId",
                        column: x => x.ColonyId,
                        principalTable: "Colony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypicalInspection_Photo_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypicalInspection_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colony_PhotoId",
                table: "Colony",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialInspection_ColonyId",
                table: "SpecialInspection",
                column: "ColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialInspection_PhotoId",
                table: "SpecialInspection",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialInspection_UserID",
                table: "SpecialInspection",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalInspection_ColonyId",
                table: "TypicalInspection",
                column: "ColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalInspection_PhotoId",
                table: "TypicalInspection",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalInspection_UserID",
                table: "TypicalInspection",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Colony_Photo_PhotoId",
                table: "Colony",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colony_Photo_PhotoId",
                table: "Colony");

            migrationBuilder.DropTable(
                name: "SpecialInspection");

            migrationBuilder.DropTable(
                name: "TypicalInspection");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Colony_PhotoId",
                table: "Colony");

            migrationBuilder.DropColumn(
                name: "Markings",
                table: "Colony");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Colony");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Host",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 691, DateTimeKind.Local).AddTicks(1365),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 38, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Host",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 691, DateTimeKind.Local).AddTicks(970),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 38, DateTimeKind.Local).AddTicks(4234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Colony",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 685, DateTimeKind.Local).AddTicks(7561),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 36, DateTimeKind.Local).AddTicks(2740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colony",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 685, DateTimeKind.Local).AddTicks(7153),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 36, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Area",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 683, DateTimeKind.Local).AddTicks(5382),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 34, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Area",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 17, 20, 12, 2, 679, DateTimeKind.Local).AddTicks(8048),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 34, DateTimeKind.Local).AddTicks(4039));
        }
    }
}
