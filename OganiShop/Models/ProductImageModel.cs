namespace AppManager.Areas.Admin.Models
{
    public class ProductImageModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FileId { get; set; }
        public string FilePath { get; set; }
        public bool IsAvatar { get; set; }
    }
}
