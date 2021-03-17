using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class RemovePhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colony_Photo_PhotoId",
                table: "Colony");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialInspection_Photo_PhotoId",
                table: "SpecialInspection");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalInspection_Photo_PhotoId",
                table: "TypicalInspection");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_TypicalInspection_PhotoId",
                table: "TypicalInspection");

            migrationBuilder.DropIndex(
                name: "IX_SpecialInspection_PhotoId",
                table: "SpecialInspection");

            migrationBuilder.DropIndex(
                name: "IX_Colony_PhotoId",
                table: "Colony");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "TypicalInspection");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "SpecialInspection");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Colony");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 55, DateTimeKind.Local).AddTicks(3352),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 33, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 55, DateTimeKind.Local).AddTicks(3029),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 33, DateTimeKind.Local).AddTicks(1635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "TypicalInspection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 53, DateTimeKind.Local).AddTicks(7821),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 31, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TypicalInspection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 53, DateTimeKind.Local).AddTicks(7439),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 31, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "SpecialInspection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 48, DateTimeKind.Local).AddTicks(9790),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 25, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SpecialInspection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 43, DateTimeKind.Local).AddTicks(5497),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 25, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Host",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 60, DateTimeKind.Local).AddTicks(5796),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 38, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Host",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 60, DateTimeKind.Local).AddTicks(5459),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 38, DateTimeKind.Local).AddTicks(4234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Colony",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 58, DateTimeKind.Local).AddTicks(1652),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 36, DateTimeKind.Local).AddTicks(2740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colony",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 58, DateTimeKind.Local).AddTicks(1302),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 36, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Area",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 56, DateTimeKind.Local).AddTicks(5298),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 34, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Area",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 56, DateTimeKind.Local).AddTicks(4982),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 34, DateTimeKind.Local).AddTicks(4039));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 33, DateTimeKind.Local).AddTicks(1998),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 55, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 33, DateTimeKind.Local).AddTicks(1635),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 55, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "TypicalInspection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 31, DateTimeKind.Local).AddTicks(807),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 53, DateTimeKind.Local).AddTicks(7821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TypicalInspection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 31, DateTimeKind.Local).AddTicks(449),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 53, DateTimeKind.Local).AddTicks(7439));

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "TypicalInspection",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "SpecialInspection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 25, DateTimeKind.Local).AddTicks(3334),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 48, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SpecialInspection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 25, DateTimeKind.Local).AddTicks(2969),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 43, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "SpecialInspection",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Host",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 38, DateTimeKind.Local).AddTicks(4577),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 60, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Host",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 38, DateTimeKind.Local).AddTicks(4234),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 60, DateTimeKind.Local).AddTicks(5459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Colony",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 36, DateTimeKind.Local).AddTicks(2740),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 58, DateTimeKind.Local).AddTicks(1652));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Colony",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 36, DateTimeKind.Local).AddTicks(2390),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 58, DateTimeKind.Local).AddTicks(1302));

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
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 56, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Area",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 34, DateTimeKind.Local).AddTicks(4039),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 3, 11, 10, 50, 16, 56, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 19, DateTimeKind.Local).AddTicks(8831)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "System"),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 3, 8, 14, 33, 36, 23, DateTimeKind.Local).AddTicks(2708)),
                    Path = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypicalInspection_PhotoId",
                table: "TypicalInspection",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialInspection_PhotoId",
                table: "SpecialInspection",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colony_PhotoId",
                table: "Colony",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colony_Photo_PhotoId",
                table: "Colony",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialInspection_Photo_PhotoId",
                table: "SpecialInspection",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalInspection_Photo_PhotoId",
                table: "TypicalInspection",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
