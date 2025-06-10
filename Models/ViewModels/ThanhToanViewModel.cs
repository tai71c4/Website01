using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebsiteBanPhuKien.Models.ViewModels
{
    public class ThanhToanViewModel
    {
        public int MaDon { get; set; }
        
        [Required(ErrorMessage = "Vui lòng chọn phương thức thanh toán")]
        public string PhuongThucThanhToan { get; set; } = string.Empty;
        
        [Display(Name = "Ảnh xác nhận thanh toán")]
        public IFormFile? AnhThanhToan { get; set; }
        
        public string? GhiChu { get; set; }
        
        public decimal TongTien { get; set; }
        
        public string? TrangThai { get; set; }

        // Thuộc tính bổ sung để tương thích với code hiện tại
        public DonHang? DonHang { get; set; }
        public PhuKien? SanPham { get; set; }
        public int SoLuong { get; set; }
        public string TenNguoiNhan { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string DiaChiGiao { get; set; } = string.Empty;
        public List<GioHangViewModel>? GioHangItems { get; set; }
    }
}