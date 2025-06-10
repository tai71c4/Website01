namespace WebsiteBanPhuKien.Models
{
    public class CartItem
    {
        public int MaPhuKien { get; set; }
        public int SoLuong { get; set; }
        
        // Thêm property này để tương thích với code hiện tại
        public int Quantity { get { return SoLuong; } set { SoLuong = value; } }
    }
}