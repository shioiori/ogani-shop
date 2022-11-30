using AppManager.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AppManager.Controllers
{
    public class CategoryRenderController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryRenderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
