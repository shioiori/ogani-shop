using AppAccountManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAccount()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var account = claims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = (from a in _dbContext.AccountManagerEntities
                        join b in _dbContext.UserEntities on a.Account equals b.Account
                        join c in _dbContext.AccountImageEntities on a.Account equals c.Account
                        join d in _dbContext.FileManageEntities on c.FileId equals d.Id
                        where a.Account == account
                        where c.IsDeleted == false && c.IsAvatar == true
                        select new UserModel()
                        {
                            Account = account,
                            FirstName = b.FirstName,
                            LastName = b.LastName,
                            Role = a.Role,
                            AvatarId = d.Id,
                            AvatarPath = d.FilePath,
                            CreatedDate = a.CreatedDate,
                        }).First();
            return Json(user);
        }
    }
}
