using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCaterer.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ResponseMessages",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 8, 2, 25, 15, 597, DateTimeKind.Local).AddTicks(9709),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 8, 8, 1, 20, 50, 356, DateTimeKind.Local).AddTicks(2331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 8, 2, 25, 15, 594, DateTimeKind.Local).AddTicks(6499),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 8, 1, 20, 50, 352, DateTimeKind.Local).AddTicks(8447));

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Caterers_Users_UserId",
                table: "Caterers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caterers_Users_UserId",
                table: "Caterers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ResponseMessages",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 8, 1, 20, 50, 356, DateTimeKind.Local).AddTicks(2331),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 8, 8, 2, 25, 15, 597, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 8, 1, 20, 50, 352, DateTimeKind.Local).AddTicks(8447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 8, 2, 25, 15, 594, DateTimeKind.Local).AddTicks(6499));

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId",
                unique: true);
        }
    }
}
