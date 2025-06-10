using Microsoft.EntityFrameworkCore;
using WebsiteBanPhuKien.Models;

namespace WebsiteBanPhuKien.Services
{
    public class ThongBaoService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ThongBaoService> _logger;

        public ThongBaoService(AppDbContext context, ILogger<ThongBaoService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> GuiThongBaoChoAdmin(string tieuDe, string noiDung, string? link = null)
        {
            try
            {
                // Tìm tất cả người dùng có vai trò Admin
                var adminUsers = await _context.UserRoles
                    .Join(_context.Roles,
                        ur => ur.RoleId,
                        r => r.Id,
                        (ur, r) => new { ur.UserId, r.Name })
                    .Where(x => x.Name == "Admin")
                    .Select(x => x.UserId)
                    .ToListAsync();

                if (!adminUsers.Any())
                {
                    _logger.LogWarning("Không tìm thấy người dùng Admin nào để gửi thông báo");
                    return false;
                }

                // Tạo thông báo cho mỗi admin
                foreach (var adminId in adminUsers)
                {
                    var thongBao = new ThongBao
                    {
                        UserId = adminId,
                        TieuDe = tieuDe,
                        NoiDung = noiDung,
                        Link = link,
                        NgayTao = DateTime.Now,
                        DaDoc = false
                    };

                    _context.ThongBaos.Add(thongBao);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gửi thông báo cho Admin");
                return false;
            }
        }

        public async Task<bool> GuiThongBaoChoNguoiDung(Guid userId, string tieuDe, string noiDung, string? link = null)
        {
            try
            {
                var thongBao = new ThongBao
                {
                    UserId = userId,
                    TieuDe = tieuDe,
                    NoiDung = noiDung,
                    Link = link,
                    NgayTao = DateTime.Now,
                    DaDoc = false
                };

                _context.ThongBaos.Add(thongBao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi gửi thông báo cho người dùng");
                return false;
            }
        }

        public async Task<List<ThongBao>> LayThongBaoChoNguoiDung(Guid userId, int soLuong = 10)
        {
            return await _context.ThongBaos
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.NgayTao)
                .Take(soLuong)
                .ToListAsync();
        }

        public async Task<bool> DanhDauDaDoc(int thongBaoId, Guid userId)
        {
            try
            {
                var thongBao = await _context.ThongBaos
                    .FirstOrDefaultAsync(t => t.Id == thongBaoId && t.UserId == userId);

                if (thongBao == null)
                    return false;

                thongBao.DaDoc = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi đánh dấu thông báo đã đọc");
                return false;
            }
        }

        public async Task<int> DemThongBaoChuaDoc(Guid userId)
        {
            return await _context.ThongBaos
                .CountAsync(t => t.UserId == userId && !t.DaDoc);
        }
    }
}