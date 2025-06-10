using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebsiteBanPhuKien.Models;

namespace WebsiteBanPhuKien.ViewComponents
{
    [ViewComponent(Name = "CartSummary")]
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public CartSummaryViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int itemCount = 0;

            var userIdString = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userIdString))
            {
                // Người dùng đã đăng nhập
                Guid userId = Guid.Parse(userIdString);
                itemCount = await _context.GioHangs
                    .Where(c => c.UserId == userId)
                    .SumAsync(c => c.SoLuong);
            }
            else
            {
                // Người dùng chưa đăng nhập, lấy từ session
                var cartJson = HttpContext.Session.GetString("Cart");
                if (!string.IsNullOrEmpty(cartJson))
                {
                    try
                    {
                        // Sử dụng class CartItem từ namespace Models
                        var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);
                        itemCount = cart?.Sum(i => i.SoLuong) ?? 0;
                    }
                    catch
                    {
                        itemCount = 0;
                    }
                }
            }

            return View(itemCount);
        }
    }
}