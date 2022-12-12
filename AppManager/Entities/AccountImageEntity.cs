using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("AccountImage")]
    public class AccountImageEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Account { get; set; }
        public int FileId { get; set; }
        public bool IsAvatar { get; set; }
    }
}
