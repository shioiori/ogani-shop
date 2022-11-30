using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("Manager")]
    public class ManagerEntity : BaseEntity
    {
        [Key]
        public string Account { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
