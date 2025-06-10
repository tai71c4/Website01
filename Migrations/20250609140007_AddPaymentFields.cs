using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteBanPhuKien.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnhThanhToan",
                table: "DonHang",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DaXacNhanThanhToan",
                table: "DonHang",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayThanhToan",
                table: "DonHang",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhuongThucThanhToan",
                table: "DonHang",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnhThanhToan",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "DaXacNhanThanhToan",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "NgayThanhToan",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "PhuongThucThanhToan",
                table: "DonHang");
        }
    }
}
