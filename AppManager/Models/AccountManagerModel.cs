using System.ComponentModel.DataAnnotations;

namespace AppManager.Areas.Admin.Models
{
    public class AccountManagerModel
    {
        [Required(ErrorMessage = "Chưa điền tên đăng nhập")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Độ dài không được vượt quá 50 ký tự")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Chưa điền mật khẩu")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Độ dài không được vượt quá 50 ký tự")]
        public string Password { get; set; }

        public string Role { get; set; }
        public string ReturnUrl { get; set; }
        
    }
}
