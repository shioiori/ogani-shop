# OganiShop
Đây là project mua sắm nguyên liệu và thực phẩm. 

Frontend được lấy từ: https://themewagon.com/themes/free-bootstrap-4-html5-responsive-ecommerce-website-template-ogani/

Frontend admin được lấy từ: https://adminlte.io/themes/AdminLTE/index2.html

## Chức năng hiện có
### Trang người dùng
#### Home
- Render sản phẩm dựa trên thông tin trong database.
- Click vào sản phẩm redirect đến trang tương ứng.
- Click vào blog redirect đến bài viết tương ứng.
#### ShoppingGrid
- Render sản phẩm dựa trên thông tin trong database. Sản phẩm xuất hiện trên mục giảm giá sẽ không xuất hiện bên dưới nữa.
- Filter theo giá.
- Filter theo thư mục.
- Paging.
#### ProductDetail
- Render sản phẩm tương ứng với link.
- Có sản phẩm tương tự.
#### ShoppingCart
- Hiển thị sản phẩm có trong giỏ. 
+ Nếu là người dùng ẩn danh, sản phẩm sẽ biến mất khi cookie hết thời hạn.
+ Nếu là người dùng đăng ký tài khoản, những thứ trong giỏ hàng luôn tồn tại.
- Có thể thay đổi số lượng + xoá sản phẩm khỏi giỏ
#### CheckOut
- Nếu lần đầu mua hàng sẽ phải điền địa chỉ trước khi check out (có validate form)
- Nếu không phải lần đầu mua, hệ thống sẽ đưa ra những địa chỉ trước đây đã từng nhập để lựa chọn hoặc điền địa chỉ mới.
- Không có gì trong giỏ hàng sẽ không thanh toán được.
#### Blog
- Render các post theo thông tin trong database.
- Click vào bài viết để đến trang tương ứng.
- Filter theo tag.
- Filter theo thư mục.
- Paging.
#### BlogDetail
- Render bài viết tương ứng.
- Có bài viết tương tự.

### Trang admin
#### Account
- Có thể đăng nhập hoặc đăng ký.
- Khi đăng ký thành công sẽ chuyển về trang đăng nhập. Tài khoản đăng ký auto tài khoản khách hàng.
- Có thể đăng xuất (cả admin lẫn người dùng)
- Hiển thị tài khoản tương ứng khi đăng nhập thành công (ở trên thanh navbar)
#### User
- Xem, sửa thông tin cá nhân + ảnh đại diện.
- Chỉ có admin mới có thể sửa vai trò.
- Chỉ có admin mới có thể xem danh sách người dùng (paging).
#### Trang chủ
- Hiển thị thống kê theo tháng và năm (gộp theo danh mục sản phẩm)
- Hiển thị những nhân viên mới và danh sách đơn hàng.
#### Product
- Hiển thị danh sách sản phẩm.
- Có thể xoá / thay đổi thông tin sản phẩm.
- Có thể thêm ảnh / đặt lại ảnh đại diện cho sản phẩm.
- Paging.
#### Category
- Hiển thị danh sách thư mục. 
- Có thể xoá / thay đổi / đặt lại ảnh cho thư mục.
- Paging.
#### Blog
- Hiển thị tất cả bài viết công khai.
- Thêm thư mục cho blog.
- Lọc theo thư mục.
- Xem + sửa + thêm bài viết của bản thân ở chế độ công khai / nháp / xoá.
- Paging.
#### Report
- Y như trang chủ nhưng cắt bỏ phần nhân viên mới + danh sách đơn hàng
