namespace AppManager.Models
{
    public class ProductDiscountModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string Category { get; set; }
        public int DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public string Avatar { get; set; }
        public int AvatarFileId { get; set; }
    }
}
