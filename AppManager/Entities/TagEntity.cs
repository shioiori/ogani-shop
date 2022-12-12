using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("Tag")]
    public class TagEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
    }
}
