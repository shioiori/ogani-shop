using System.Collections.Generic;

namespace AppManager.Models
{
    public class CategoryProductModel
    {
        public int CategoryId { get; set; }
        public string CategorySlug { get; set; }
        public string CategoryName { get; set; }
        public List<ProductModel> ListProduct { get; set; }
    }
}
