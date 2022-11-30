namespace AppManager.Areas.Admin.Models
{
    public class RequestModel
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string FreeText { get; set; }
    }
}
