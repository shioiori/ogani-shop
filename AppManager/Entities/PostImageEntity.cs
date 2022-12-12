using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("PostImage")]
    public class PostImageEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int FileId { get; set; }
        public bool IsAvatar { get; set; }
    }
}
