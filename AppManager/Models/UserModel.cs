using System;
using System.ComponentModel.DataAnnotations;

namespace AppManager.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Độ dài không được vượt quá 50 ký tự")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Độ dài không được vượt quá 50 ký tự")]
        public string Password { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Độ dài không được vượt quá 50 ký tự")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Độ dài không được vượt quá 50 ký tự")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AvatarId { get; set; }
        [Required(ErrorMessage = "Ảnh đại diện không được để trống")]
        public string AvatarPath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
