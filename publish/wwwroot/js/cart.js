// Cart functionality
function updateCartItem(maPhuKien, soLuong) {
    $.ajax({
        url: '/Cart/CapNhatGioHang',
        type: 'POST',
        data: {
            maPhuKien: maPhuKien,
            soLuong: soLuong
        },
        success: function(result) {
            location.reload();
        },
        error: function() {
            alert('Có lỗi xảy ra khi cập nhật giỏ hàng.');
        }
    });
}

function removeCartItem(maPhuKien) {
    if (confirm('Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng?')) {
        $.ajax({
            url: '/Cart/XoaKhoiGioHang',
            type: 'POST',
            data: {
                maPhuKien: maPhuKien
            },
            success: function(result) {
                location.reload();
            },
            error: function() {
                alert('Có lỗi xảy ra khi xóa sản phẩm khỏi giỏ hàng.');
            }
        });
    }
}

function clearCart() {
    if (confirm('Bạn có chắc chắn muốn xóa tất cả sản phẩm khỏi giỏ hàng?')) {
        $.ajax({
            url: '/Cart/XoaGioHang',
            type: 'POST',
            success: function(result) {
                location.reload();
            },
            error: function() {
                alert('Có lỗi xảy ra khi xóa giỏ hàng.');
            }
        });
    }
}