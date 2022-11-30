using System;

namespace AppManager.Models
{
    public class DiscountModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
