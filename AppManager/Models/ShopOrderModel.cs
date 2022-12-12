using System;

namespace AppManager.Models
{
    public class ShopOrderModel
    {
        public int ShopOrderId { get; set; }
        public int OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public string Account { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
