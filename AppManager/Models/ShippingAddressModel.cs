using System.ComponentModel.DataAnnotations;

namespace AppManager.Models
{
    public class ShippingAddressModel
    {
        public int Id { get; set; }
        public string Account { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Độ dài không được vượt quá 50 ký tự")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Độ dài không được vượt quá 50 ký tự")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Độ dài không được vượt quá 1000 ký tự")]
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string Postcode { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }

        [StringLength(200, MinimumLength = 0, ErrorMessage = "Độ dài không được vượt quá 200 ký tự")]
        public string Note { get; set; }
    }
}
