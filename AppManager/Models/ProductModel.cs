using System;

namespace AppManager.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string Unit { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Avatar { get; set; }
        public int AvatarFileId { get; set; }
        public int CartId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
