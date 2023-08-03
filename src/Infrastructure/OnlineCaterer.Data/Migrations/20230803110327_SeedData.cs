using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCaterer.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string userId = Guid.NewGuid().ToString();
            migrationBuilder.InsertData(
                table: "Users",
                columns: new string[]
                {
                    "Id",
                    "Name",
                    "Address",
                    "Email",
                    "EmailConfirmed",
                    "PhoneNumber",
                    "PhoneNumberConfirmed",
                    "UserName",
                    "TwoFactorEnabled",
                    "LockoutEnabled",
                    "AccessFailedCount",
                },
                values: new object[]
                {
                    userId,
                    "Aptech Le Thanh Nghi",
                    "19 Le Thanh Nghi, Hai Ba Trung, Ha Noi, Viet Nam",
                    "apecth.ltn@aptech.vn",
                    true,
                    "0123456789",
                    true,
                    "aptech",
                    false,
                    false,
                    0,
                }
            );

            migrationBuilder.InsertData(
                table: "Caterers",
                columns: new string[]
                {
                    "UserId",
                    "CreatedDate",
                    "CreatedBy",
                    "LastModifiedDate",
                    "LastModifiedBy",
                },
                values: new object[]
                {
                    userId,
                    DateTime.Now,
                    userId,
                    DateTime.Now,
                    userId,
                }
            );

            // seed roles
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new string[]
                {
                    "Id",
                    "Name",
                },
                values: new object[]
                {
                    Guid.NewGuid().ToString(),
                    "Caterer"
                }
            );

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new string[]
                {
                    "Id",
                    "Name",
                },
                values: new object[]
                {
                    Guid.NewGuid().ToString(),
                    "Customer"
                }
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ResponseMessages",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 3, 27, 873, DateTimeKind.Local).AddTicks(2700),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 8, 3, 12, 11, 59, 454, DateTimeKind.Local).AddTicks(974));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 3, 27, 868, DateTimeKind.Local).AddTicks(9831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 3, 12, 11, 59, 450, DateTimeKind.Local).AddTicks(1945));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ResponseMessages",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 12, 11, 59, 454, DateTimeKind.Local).AddTicks(974),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 3, 27, 873, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 12, 11, 59, 450, DateTimeKind.Local).AddTicks(1945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 3, 27, 868, DateTimeKind.Local).AddTicks(9831));
        }
    }
}
