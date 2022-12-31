using AppAccountManager.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AppManager.Controllers
{
    public class TestController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TestController(AppDbContext dbContext) {
            {
                _dbContext = dbContext;
            } }
        public IActionResult Index()
        {
            var query = _dbContext.CategoryBlogEntities.Where(x => x.IsDeleted == false);
            return Json(query);
        }
    }
}
