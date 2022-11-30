using AppManager.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AppManager.Controllers
{
    public class ProductRenderController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductRenderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetail ()
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }

        public IActionResult ShoppingGrid()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var prd = _dbContext.ProductEntities.ToList();
            return Json(prd);
        }
    }
}
