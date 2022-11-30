using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("Banner")]
    public class BannerEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int FileId { get; set; }
        public int Type { get; set; }
    }
}
