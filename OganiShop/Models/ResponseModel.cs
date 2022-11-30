using System.Collections.Generic;

namespace AppManager.Areas.Admin.Models
{
    public class ResponseModel<T> where T : class
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
