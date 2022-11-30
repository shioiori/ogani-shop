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
        public DateTime SaleDay { get; set; }
        public int OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
