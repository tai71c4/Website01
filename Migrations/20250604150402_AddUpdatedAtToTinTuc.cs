using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteBanPhuKien.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAtToTinTuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BinhLuans_AspNetUsers_UserId",
                table: "BinhLuans");

            migrationBuilder.DropForeignKey(
                name: "FK_BinhLuans_TinTucs_MaTin",
                table: "BinhLuans");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHangs_DonHangs_MaDon",
                table: "ChiTietDonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHangs_PhuKiens_MaPhuKien",
                table: "ChiTietDonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhGias_AspNetUsers_UserId",
                table: "DanhGias");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhGias_PhuKiens_MaPhuKien",
                table: "DanhGias");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHangs_AspNetUsers_CreatedBy",
                table: "DonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHangs_AspNetUsers_UpdatedBy",
                table: "DonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHangs_AspNetUsers_UserId",
                table: "DonHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_GioHangs_AspNetUsers_UserId",
                table: "GioHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_GioHangs_PhuKiens_MaPhuKien",
                table: "GioHangs");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuKiens_HangSanXuats_MaHang",
                table: "PhuKiens");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuKiens_LoaiPhuKiens_MaLoai",
                table: "PhuKiens");

            migrationBuilder.DropForeignKey(
                name: "FK_TinTucs_ChuDeTinTucs_MaChuDe",
                table: "TinTucs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TinTucs",
                table: "TinTucs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhuKiens",
                table: "PhuKiens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiPhuKiens",
                table: "LoaiPhuKiens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LienHes",
                table: "LienHes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HangSanXuats",
                table: "HangSanXuats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GioHangs",
                table: "GioHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonHangs",
                table: "DonHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhGias",
                table: "DanhGias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChuDeTinTucs",
                table: "ChuDeTinTucs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDonHangs",
                table: "ChiTietDonHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BinhLuans",
                table: "BinhLuans");

            migrationBuilder.DropColumn(
                name: "GiaBan",
                table: "PhuKiens");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "LoaiPhuKiens");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "LoaiPhuKiens");

            migrationBuilder.DropColumn(
                name: "DaXem",
                table: "LienHes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HangSanXuats");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "HangSanXuats");

            migrationBuilder.RenameTable(
                name: "TinTucs",
                newName: "TinTuc");

            migrationBuilder.RenameTable(
                name: "PhuKiens",
                newName: "PhuKien");

            migrationBuilder.RenameTable(
                name: "LoaiPhuKiens",
                newName: "LoaiPhuKien");

            migrationBuilder.RenameTable(
                name: "LienHes",
                newName: "LienHe");

            migrationBuilder.RenameTable(
                name: "HangSanXuats",
                newName: "Hang");

            migrationBuilder.RenameTable(
                name: "GioHangs",
                newName: "GioHang");

            migrationBuilder.RenameTable(
                name: "DonHangs",
                newName: "DonHang");

            migrationBuilder.RenameTable(
                name: "DanhGias",
                newName: "DanhGia");

            migrationBuilder.RenameTable(
                name: "ChuDeTinTucs",
                newName: "ChuDe");

            migrationBuilder.RenameTable(
                name: "ChiTietDonHangs",
                newName: "ChiTietDonHang");

            migrationBuilder.RenameTable(
                name: "BinhLuans",
                newName: "BinhLuan");

            migrationBuilder.RenameIndex(
                name: "IX_TinTucs_MaChuDe",
                table: "TinTuc",
                newName: "IX_TinTuc_MaChuDe");

            migrationBuilder.RenameIndex(
                name: "IX_PhuKiens_MaLoai",
                table: "PhuKien",
                newName: "IX_PhuKien_MaLoai");

            migrationBuilder.RenameIndex(
                name: "IX_PhuKiens_MaHang",
                table: "PhuKien",
                newName: "IX_PhuKien_MaHang");

            migrationBuilder.RenameIndex(
                name: "IX_GioHangs_UserId_MaPhuKien",
                table: "GioHang",
                newName: "IX_GioHang_UserId_MaPhuKien");

            migrationBuilder.RenameIndex(
                name: "IX_GioHangs_MaPhuKien",
                table: "GioHang",
                newName: "IX_GioHang_MaPhuKien");

            migrationBuilder.RenameIndex(
                name: "IX_DonHangs_UserId",
                table: "DonHang",
                newName: "IX_DonHang_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHangs_UpdatedBy",
                table: "DonHang",
                newName: "IX_DonHang_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_DonHangs_CreatedBy",
                table: "DonHang",
                newName: "IX_DonHang_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGias_UserId",
                table: "DanhGia",
                newName: "IX_DanhGia_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGias_MaPhuKien",
                table: "DanhGia",
                newName: "IX_DanhGia_MaPhuKien");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonHangs_MaPhuKien",
                table: "ChiTietDonHang",
                newName: "IX_ChiTietDonHang_MaPhuKien");

            migrationBuilder.RenameIndex(
                name: "IX_BinhLuans_UserId",
                table: "BinhLuan",
                newName: "IX_BinhLuan_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BinhLuans_MaTin",
                table: "BinhLuan",
                newName: "IX_BinhLuan_MaTin");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "TieuDe",
                table: "TinTuc",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TinTuc",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoai",
                table: "LoaiPhuKien",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "LienHe",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "LienHe",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "LienHe",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenHang",
                table: "Hang",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "DonHang",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenChuDe",
                table: "ChuDe",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ChiTietDonHang",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TinTuc",
                table: "TinTuc",
                column: "MaTin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhuKien",
                table: "PhuKien",
                column: "MaPhuKien");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiPhuKien",
                table: "LoaiPhuKien",
                column: "MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LienHe",
                table: "LienHe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hang",
                table: "Hang",
                column: "MaHang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GioHang",
                table: "GioHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonHang",
                table: "DonHang",
                column: "MaDon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhGia",
                table: "DanhGia",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChuDe",
                table: "ChuDe",
                column: "MaChuDe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDonHang",
                table: "ChiTietDonHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BinhLuan",
                table: "BinhLuan",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_MaDon",
                table: "ChiTietDonHang",
                column: "MaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_BinhLuan_AspNetUsers_UserId",
                table: "BinhLuan",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BinhLuan_TinTuc_MaTin",
                table: "BinhLuan",
                column: "MaTin",
                principalTable: "TinTuc",
                principalColumn: "MaTin",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_DonHang_MaDon",
                table: "ChiTietDonHang",
                column: "MaDon",
                principalTable: "DonHang",
                principalColumn: "MaDon",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_PhuKien_MaPhuKien",
                table: "ChiTietDonHang",
                column: "MaPhuKien",
                principalTable: "PhuKien",
                principalColumn: "MaPhuKien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGia_AspNetUsers_UserId",
                table: "DanhGia",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGia_PhuKien_MaPhuKien",
                table: "DanhGia",
                column: "MaPhuKien",
                principalTable: "PhuKien",
                principalColumn: "MaPhuKien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_AspNetUsers_CreatedBy",
                table: "DonHang",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_AspNetUsers_UpdatedBy",
                table: "DonHang",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_AspNetUsers_UserId",
                table: "DonHang",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GioHang_AspNetUsers_UserId",
                table: "GioHang",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GioHang_PhuKien_MaPhuKien",
                table: "GioHang",
                column: "MaPhuKien",
                principalTable: "PhuKien",
                principalColumn: "MaPhuKien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuKien_Hang_MaHang",
                table: "PhuKien",
                column: "MaHang",
                principalTable: "Hang",
                principalColumn: "MaHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuKien_LoaiPhuKien_MaLoai",
                table: "PhuKien",
                column: "MaLoai",
                principalTable: "LoaiPhuKien",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TinTuc_ChuDe_MaChuDe",
                table: "TinTuc",
                column: "MaChuDe",
                principalTable: "ChuDe",
                principalColumn: "MaChuDe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BinhLuan_AspNetUsers_UserId",
                table: "BinhLuan");

            migrationBuilder.DropForeignKey(
                name: "FK_BinhLuan_TinTuc_MaTin",
                table: "BinhLuan");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_DonHang_MaDon",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_PhuKien_MaPhuKien",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhGia_AspNetUsers_UserId",
                table: "DanhGia");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhGia_PhuKien_MaPhuKien",
                table: "DanhGia");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_AspNetUsers_CreatedBy",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_AspNetUsers_UpdatedBy",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_AspNetUsers_UserId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_GioHang_AspNetUsers_UserId",
                table: "GioHang");

            migrationBuilder.DropForeignKey(
                name: "FK_GioHang_PhuKien_MaPhuKien",
                table: "GioHang");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuKien_Hang_MaHang",
                table: "PhuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuKien_LoaiPhuKien_MaLoai",
                table: "PhuKien");

            migrationBuilder.DropForeignKey(
                name: "FK_TinTuc_ChuDe_MaChuDe",
                table: "TinTuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TinTuc",
                table: "TinTuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhuKien",
                table: "PhuKien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiPhuKien",
                table: "LoaiPhuKien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LienHe",
                table: "LienHe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hang",
                table: "Hang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GioHang",
                table: "GioHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonHang",
                table: "DonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhGia",
                table: "DanhGia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChuDe",
                table: "ChuDe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDonHang",
                table: "ChiTietDonHang");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietDonHang_MaDon",
                table: "ChiTietDonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BinhLuan",
                table: "BinhLuan");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TinTuc");

            migrationBuilder.RenameTable(
                name: "TinTuc",
                newName: "TinTucs");

            migrationBuilder.RenameTable(
                name: "PhuKien",
                newName: "PhuKiens");

            migrationBuilder.RenameTable(
                name: "LoaiPhuKien",
                newName: "LoaiPhuKiens");

            migrationBuilder.RenameTable(
                name: "LienHe",
                newName: "LienHes");

            migrationBuilder.RenameTable(
                name: "Hang",
                newName: "HangSanXuats");

            migrationBuilder.RenameTable(
                name: "GioHang",
                newName: "GioHangs");

            migrationBuilder.RenameTable(
                name: "DonHang",
                newName: "DonHangs");

            migrationBuilder.RenameTable(
                name: "DanhGia",
                newName: "DanhGias");

            migrationBuilder.RenameTable(
                name: "ChuDe",
                newName: "ChuDeTinTucs");

            migrationBuilder.RenameTable(
                name: "ChiTietDonHang",
                newName: "ChiTietDonHangs");

            migrationBuilder.RenameTable(
                name: "BinhLuan",
                newName: "BinhLuans");

            migrationBuilder.RenameIndex(
                name: "IX_TinTuc_MaChuDe",
                table: "TinTucs",
                newName: "IX_TinTucs_MaChuDe");

            migrationBuilder.RenameIndex(
                name: "IX_PhuKien_MaLoai",
                table: "PhuKiens",
                newName: "IX_PhuKiens_MaLoai");

            migrationBuilder.RenameIndex(
                name: "IX_PhuKien_MaHang",
                table: "PhuKiens",
                newName: "IX_PhuKiens_MaHang");

            migrationBuilder.RenameIndex(
                name: "IX_GioHang_UserId_MaPhuKien",
                table: "GioHangs",
                newName: "IX_GioHangs_UserId_MaPhuKien");

            migrationBuilder.RenameIndex(
                name: "IX_GioHang_MaPhuKien",
                table: "GioHangs",
                newName: "IX_GioHangs_MaPhuKien");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_UserId",
                table: "DonHangs",
                newName: "IX_DonHangs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_UpdatedBy",
                table: "DonHangs",
                newName: "IX_DonHangs_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_CreatedBy",
                table: "DonHangs",
                newName: "IX_DonHangs_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGia_UserId",
                table: "DanhGias",
                newName: "IX_DanhGias_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGia_MaPhuKien",
                table: "DanhGias",
                newName: "IX_DanhGias_MaPhuKien");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDonHang_MaPhuKien",
                table: "ChiTietDonHangs",
                newName: "IX_ChiTietDonHangs_MaPhuKien");

            migrationBuilder.RenameIndex(
                name: "IX_BinhLuan_UserId",
                table: "BinhLuans",
                newName: "IX_BinhLuans_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BinhLuan_MaTin",
                table: "BinhLuans",
                newName: "IX_BinhLuans_MaTin");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TieuDe",
                table: "TinTucs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaBan",
                table: "PhuKiens",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "TenLoai",
                table: "LoaiPhuKiens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "LoaiPhuKiens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "LoaiPhuKiens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "LienHes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "LienHes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "LienHes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DaXem",
                table: "LienHes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TenHang",
                table: "HangSanXuats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HangSanXuats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "HangSanXuats",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "DonHangs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TenChuDe",
                table: "ChuDeTinTucs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ChiTietDonHangs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TinTucs",
                table: "TinTucs",
                column: "MaTin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhuKiens",
                table: "PhuKiens",
                column: "MaPhuKien");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiPhuKiens",
                table: "LoaiPhuKiens",
                column: "MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LienHes",
                table: "LienHes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HangSanXuats",
                table: "HangSanXuats",
                column: "MaHang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GioHangs",
                table: "GioHangs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonHangs",
                table: "DonHangs",
                column: "MaDon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhGias",
                table: "DanhGias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChuDeTinTucs",
                table: "ChuDeTinTucs",
                column: "MaChuDe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDonHangs",
                table: "ChiTietDonHangs",
                columns: new[] { "MaDon", "MaPhuKien" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BinhLuans",
                table: "BinhLuans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BinhLuans_AspNetUsers_UserId",
                table: "BinhLuans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BinhLuans_TinTucs_MaTin",
                table: "BinhLuans",
                column: "MaTin",
                principalTable: "TinTucs",
                principalColumn: "MaTin",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHangs_DonHangs_MaDon",
                table: "ChiTietDonHangs",
                column: "MaDon",
                principalTable: "DonHangs",
                principalColumn: "MaDon",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHangs_PhuKiens_MaPhuKien",
                table: "ChiTietDonHangs",
                column: "MaPhuKien",
                principalTable: "PhuKiens",
                principalColumn: "MaPhuKien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGias_AspNetUsers_UserId",
                table: "DanhGias",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGias_PhuKiens_MaPhuKien",
                table: "DanhGias",
                column: "MaPhuKien",
                principalTable: "PhuKiens",
                principalColumn: "MaPhuKien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHangs_AspNetUsers_CreatedBy",
                table: "DonHangs",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHangs_AspNetUsers_UpdatedBy",
                table: "DonHangs",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHangs_AspNetUsers_UserId",
                table: "DonHangs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangs_AspNetUsers_UserId",
                table: "GioHangs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangs_PhuKiens_MaPhuKien",
                table: "GioHangs",
                column: "MaPhuKien",
                principalTable: "PhuKiens",
                principalColumn: "MaPhuKien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuKiens_HangSanXuats_MaHang",
                table: "PhuKiens",
                column: "MaHang",
                principalTable: "HangSanXuats",
                principalColumn: "MaHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuKiens_LoaiPhuKiens_MaLoai",
                table: "PhuKiens",
                column: "MaLoai",
                principalTable: "LoaiPhuKiens",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TinTucs_ChuDeTinTucs_MaChuDe",
                table: "TinTucs",
                column: "MaChuDe",
                principalTable: "ChuDeTinTucs",
                principalColumn: "MaChuDe");
        }
    }
}
