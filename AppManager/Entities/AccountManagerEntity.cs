using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("AccountManager")]
    public class AccountManagerEntity : BaseEntity
    {
        [Key]
        public string Account { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
