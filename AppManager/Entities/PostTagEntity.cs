using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("PostTag")]
    public class PostTagEntity : BaseEntity
    {
        [Key]
        public int PostId { get; set; }
        [Key]
        public int TagId { get; set; }
    }
}
