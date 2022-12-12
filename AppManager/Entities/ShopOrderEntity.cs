using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("ShopOrder")]
    public class ShopOrderEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public int AddressId { get; set; }
        public string Account { get; set; }
    }
}
