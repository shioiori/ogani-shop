using System.Collections.Generic;

namespace AppManager.Models
{
    public class ShoppingGridModel
    {
        public List<ProductDiscountModel> Discount { get; set; }
        public int Count { get; set; }
        public List<ProductModel> ListProduct { get; set; }
    }
}
