
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCaterer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
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

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
