using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("CategoryBlog")]
    public class CategoryBlogEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public int PostQuantity { get; set; }
    }
}
