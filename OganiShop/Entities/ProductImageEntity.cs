using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("ProductImage")]
    public class ProductImageEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FileId { get; set; }
        public bool IsAvatar { get; set; }
    }
}
