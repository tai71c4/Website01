using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebsiteBanPhuKien.Models;
using WebsiteBanPhuKien.Services;

namespace WebsiteBanPhuKien.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NotificationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ThongBaoService _thongBaoService;

        public NotificationController(
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
            ThongBaoService thongBaoService)
        {
            _context = context;
            _userManager = userManager;
            _thongBaoService = thongBaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetThongBaoMoi()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var thongBaos = await _context.ThongBaos
                .Where(t => t.UserId == user.Id && !t.DaDoc)
                .OrderByDescending(t => t.NgayTao)
                .ToListAsync();

            return Json(thongBaos);
        }

        [HttpPost]
        public async Task<IActionResult> DanhDauDaDoc(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var thongBao = await _context.ThongBaos
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == user.Id);

            if (thongBao == null)
            {
                return NotFound();
            }

            thongBao.DaDoc = true;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XacNhanThanhToan(int id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            // Cập nhật trạng thái đơn hàng
            donHang.ThanhToan = true;
            donHang.DaXacNhanThanhToan = true;
            donHang.TrangThai = "Đang xử lý";
            donHang.UpdatedAt = DateTime.Now;
            donHang.UpdatedBy = user.Id;

            await _context.SaveChangesAsync();

            // Gửi thông báo cho khách hàng
            await _thongBaoService.GuiThongBaoChoNguoiDung(
                donHang.UserId,
                "Thanh toán đã được xác nhận",
                $"Thanh toán cho đơn hàng #{donHang.MaDon} đã được xác nhận. Đơn hàng của bạn đang được xử lý.",
                $"/Order/ChiTiet/{donHang.MaDon}"
            );

            TempData["SuccessMessage"] = "Xác nhận thanh toán thành công.";
            return RedirectToAction("QuanLyDonHang", "Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TuChoiThanhToan(int id, string lyDo)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            // Cập nhật trạng thái đơn hàng
            donHang.ThanhToan = false;
            donHang.TrangThai = "Chờ thanh toán";
            donHang.UpdatedAt = DateTime.Now;
            donHang.UpdatedBy = user.Id;

            await _context.SaveChangesAsync();

            // Gửi thông báo cho khách hàng
            string noiDung = $"Thanh toán cho đơn hàng #{donHang.MaDon} đã bị từ chối.";
            if (!string.IsNullOrEmpty(lyDo))
            {
                noiDung += $" Lý do: {lyDo}";
            }

            await _thongBaoService.GuiThongBaoChoNguoiDung(
                donHang.UserId,
                "Thanh toán bị từ chối",
                noiDung,
                $"/Order/ChiTiet/{donHang.MaDon}"
            );

            TempData["SuccessMessage"] = "Đã từ chối thanh toán.";
            return RedirectToAction("QuanLyDonHang", "Admin");
        }
    }
}