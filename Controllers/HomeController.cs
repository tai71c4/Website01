using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using WebsiteBanPhuKien.Models;

namespace WebsiteBanPhuKien.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Lấy sản phẩm mới
                var sanPhamMoi = await _context.PhuKiens
                    .FromSqlRaw(@"
                        SELECT p.MaPhuKien, p.TenPhuKien, p.Gia, 
                               ISNULL(p.MoTa, '') as MoTa, 
                               ISNULL(p.HinhAnh, '') as HinhAnh, 
                               p.SoLuong, p.MaLoai, p.MaHang, 
                               p.CreatedAt, p.UpdatedAt
                        FROM PhuKien p
                        ORDER BY p.CreatedAt DESC
                        OFFSET 0 ROWS FETCH NEXT 8 ROWS ONLY")
                    .ToListAsync();

                // Tải thông tin loại và hãng riêng biệt
                foreach (var item in sanPhamMoi)
                {
                    var loai = await _context.LoaiPhuKiens.FindAsync(item.MaLoai);
                    var hang = await _context.HangSanXuats.FindAsync(item.MaHang);
                    if (loai != null) item.LoaiPhuKien = loai;
                    if (hang != null) item.HangSanXuat = hang;
                }

                // Lấy tin tức mới
                var tinTucMoi = await _context.TinTucs
                    .OrderByDescending(t => t.NgayDang)
                    .Take(3)
                    .ToListAsync();

                ViewBag.SanPhamMoi = sanPhamMoi;
                ViewBag.TinTucMoi = tinTucMoi;

                // Lấy danh sách loại phụ kiện từ database
                var loaiPhuKiens = await _context.LoaiPhuKiens.ToListAsync();
                
                // Danh mục nổi bật
                var danhMucNoiBat = new List<string>
                {
                    "Ốp lưng điện thoại",
                    "Kính và cường lực",
                    "Cáp sạc & củ sạc",
                    "Pin dự phòng",
                    "Tai nghe & âm thanh"
                };
                
                ViewBag.DanhMucNoiBat = danhMucNoiBat;
                
                // Tạo mapping giữa tên danh mục và ID loại phụ kiện
                var loaiPhuKienMap = new Dictionary<string, int>();
                
                // Tìm loại phụ kiện theo tên cụ thể
                var oplungLoai = loaiPhuKiens.FirstOrDefault(l => l.TenLoai.Contains("Ốp") || l.TenLoai.Contains("ốp"));
                var kinhLoai = loaiPhuKiens.FirstOrDefault(l => l.TenLoai.Contains("Kính") || l.TenLoai.Contains("kính"));
                var capsacLoai = loaiPhuKiens.FirstOrDefault(l => l.TenLoai.Contains("Cáp") || l.TenLoai.Contains("cáp") || l.TenLoai.Contains("Sạc") || l.TenLoai.Contains("sạc"));
                var pinLoai = loaiPhuKiens.FirstOrDefault(l => l.TenLoai.Contains("Pin") || l.TenLoai.Contains("pin"));
                var taingheLoai = loaiPhuKiens.FirstOrDefault(l => l.TenLoai.Contains("Tai") || l.TenLoai.Contains("tai") || l.TenLoai.Contains("nghe"));
                
                // Gán ID loại phụ kiện cho từng danh mục
                if (oplungLoai != null) loaiPhuKienMap["Ốp lưng điện thoại"] = oplungLoai.MaLoai;
                if (kinhLoai != null) loaiPhuKienMap["Kính và cường lực"] = kinhLoai.MaLoai;
                if (capsacLoai != null) loaiPhuKienMap["Cáp sạc & củ sạc"] = capsacLoai.MaLoai;
                if (pinLoai != null) loaiPhuKienMap["Pin dự phòng"] = pinLoai.MaLoai;
                if (taingheLoai != null) loaiPhuKienMap["Tai nghe & âm thanh"] = taingheLoai.MaLoai;
                
                // Nếu không tìm thấy loại phụ kiện, sử dụng ID mặc định
                if (!loaiPhuKienMap.ContainsKey("Ốp lưng điện thoại") && loaiPhuKiens.Any())
                    loaiPhuKienMap["Ốp lưng điện thoại"] = loaiPhuKiens.First().MaLoai;
                    
                if (!loaiPhuKienMap.ContainsKey("Kính và cường lực") && loaiPhuKiens.Any())
                    loaiPhuKienMap["Kính và cường lực"] = loaiPhuKiens.First().MaLoai;
                
                ViewBag.LoaiPhuKienMap = loaiPhuKienMap;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy dữ liệu cho trang chủ");
                // Không làm gì, để ViewBag là null và view sẽ xử lý
            }

            return View();
        }

        public IActionResult GioiThieu()
        {
            return View();
        }

        public IActionResult LienHe()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}