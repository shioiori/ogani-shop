using System;

namespace AppManager.Models
{
    public class UserModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AvatarId { get; set; }
        public string AvatarPath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
