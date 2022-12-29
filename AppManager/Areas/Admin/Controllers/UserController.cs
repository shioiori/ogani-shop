using AppAccountManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult ListUser(string name, string role, int pageNumber = 1)
        {
            int pageSize = 5;
            var query = (from a in _dbContext.AccountManagerEntities
                         join b in _dbContext.AccountImageEntities on a.Account equals b.Account
                         join c in _dbContext.FileManageEntities on b.FileId equals c.Id
                         join d in _dbContext.UserEntities on a.Account equals d.Account
                         where d.IsDeleted == false
                         where string.IsNullOrEmpty(name) || (d.FirstName + d.LastName).ToLower().Contains(name.Trim().ToLower())
                         where string.IsNullOrEmpty(role) || a.Role == role
                         where b.IsAvatar == true && b.IsDeleted == false
                         select new UserModel()
                         {
                             Account = a.Account,
                             FirstName = d.FirstName,
                             LastName = d.LastName,
                             Role = a.Role,
                             AvatarId = c.Id,
                             AvatarPath = c.FilePath
                         }).ToList();
            var total = query.Count();
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.name = name;
            ViewBag.role = role;
            var listUser = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            return View(listUser);
        }
    }
}
