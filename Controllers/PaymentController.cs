using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using WebsiteBanPhuKien.Models;
using WebsiteBanPhuKien.Models.ViewModels;
using WebsiteBanPhuKien.Services;

namespace WebsiteBanPhuKien.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly ThongBaoService _thongBaoService;
        private readonly ILogger<PaymentController> _logger;
        private readonly IConfiguration _configuration;

        public PaymentController(
            AppDbContext context,
            IWebHostEnvironment environment,
            ThongBaoService thongBaoService,
            ILogger<PaymentController> logger,
            IConfiguration configuration)
        {
            _context = context;
            _environment = environment;
            _thongBaoService = thongBaoService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> XacNhanThanhToan(int id)
        {
            var donHang = await _context.DonHangs
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.MaDon == id);

            if (donHang == null)
            {
                return NotFound();
            }

            // Kiểm tra quyền truy cập
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null || donHang.UserId != Guid.Parse(userIdClaim.Value))
            {
                return Forbid();
            }

            var viewModel = new ThanhToanViewModel
            {
                MaDon = donHang.MaDon,
                TongTien = donHang.TongTien,
                TrangThai = donHang.TrangThai,
                PhuongThucThanhToan = donHang.PhuongThucThanhToan ?? "MoMo"
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XacNhanThanhToan(ThanhToanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var donHang = await _context.DonHangs.FindAsync(model.MaDon);
            if (donHang == null)
            {
                return NotFound();
            }

            // Kiểm tra quyền truy cập
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null || donHang.UserId != Guid.Parse(userIdClaim.Value))
            {
                return Forbid();
            }

            try
            {
                // Xử lý tải lên hình ảnh thanh toán
                if (model.AnhThanhToan != null && model.AnhThanhToan.Length > 0)
                {
                    // Lấy cấu hình từ appsettings.json
                    var uploadPath = _configuration["PaymentSettings:UploadPath"] ?? "uploads/payments";
                    var maxFileSize = _configuration.GetValue<long>("PaymentSettings:MaxFileSize", 5 * 1024 * 1024); // Mặc định 5MB
                    var allowedFileTypes = _configuration.GetSection("PaymentSettings:AllowedFileTypes").Get<string[]>() ?? new[] { ".jpg", ".jpeg", ".png" };

                    // Kiểm tra kích thước file
                    if (model.AnhThanhToan.Length > maxFileSize)
                    {
                        ModelState.AddModelError("AnhThanhToan", "Kích thước file quá lớn. Vui lòng chọn file nhỏ hơn 5MB.");
                        return View(model);
                    }

                    // Kiểm tra loại file
                    var fileExtension = Path.GetExtension(model.AnhThanhToan.FileName).ToLowerInvariant();
                    if (!Array.Exists(allowedFileTypes, ext => ext.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)))
                    {
                        ModelState.AddModelError("AnhThanhToan", "Loại file không được hỗ trợ. Vui lòng chọn file JPG, JPEG hoặc PNG.");
                        return View(model);
                    }

                    // Tạo thư mục nếu chưa tồn tại
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, uploadPath);
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Tạo tên file duy nhất
                    var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(model.AnhThanhToan.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Lưu file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.AnhThanhToan.CopyToAsync(fileStream);
                    }

                    // Cập nhật thông tin đơn hàng
                    donHang.PhuongThucThanhToan = model.PhuongThucThanhToan;
                    donHang.AnhThanhToan = $"/{uploadPath}/{uniqueFileName}";
                    donHang.NgayThanhToan = DateTime.Now;
                    donHang.UpdatedAt = DateTime.Now;

                    await _context.SaveChangesAsync();

                    // Gửi thông báo cho admin
                    await _thongBaoService.GuiThongBaoChoAdmin(
                        _configuration["NotificationSettings:NotificationTitle"] ?? "Xác nhận thanh toán mới",
                        $"Đơn hàng #{donHang.MaDon} đã được thanh toán qua {model.PhuongThucThanhToan}. Vui lòng kiểm tra và xác nhận.",
                        $"/Admin/QuanLyDonHang?id={donHang.MaDon}"
                    );

                    TempData["SuccessMessage"] = "Xác nhận thanh toán thành công. Chúng tôi sẽ kiểm tra và cập nhật trạng thái đơn hàng của bạn.";
                    return RedirectToAction("ChiTiet", "Order", new { id = donHang.MaDon });
                }
                else
                {
                    ModelState.AddModelError("AnhThanhToan", "Vui lòng tải lên ảnh xác nhận thanh toán.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xác nhận thanh toán: {Message}", ex.Message);
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi xử lý thanh toán. Vui lòng thử lại sau.");
                return View(model);
            }
        }
    }
}