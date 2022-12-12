namespace AppManager.Areas.Admin.Models
{
    public class AccountManagerModel
    {
        public string Account { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
        public string ReturnUrl { get; set; }
        
    }
}
