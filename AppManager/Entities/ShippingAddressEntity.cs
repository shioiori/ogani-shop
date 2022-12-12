using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("ShippingAddress")]
    public class ShippingAddressEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Account { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}
