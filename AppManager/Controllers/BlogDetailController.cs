using AppAccountManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AppManager.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BlogDetailController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Post(int id)
        {
            var query = (from a in _dbContext.PostEntities
                         join b in _dbContext.CategoryBlogEntities on a.CategoryId equals b.Id
                         join e in _dbContext.AccountManagerEntities on a.CreatedBy equals e.Account
                         join f in _dbContext.AccountImageEntities on e.Account equals f.Account
                         join g in _dbContext.FileManageEntities on f.FileId equals g.Id
                         join h in _dbContext.UserEntities on e.Account equals h.Account
                         where a.IsDeleted == false && a.Id == id
                         where f.IsAvatar == true
                         select new PostDetailModel()
                         {
                             Id = a.Id,
                             Title = a.Title,
                             AuthorName = h.FirstName + " " + h.LastName,
                             CreatedDate = a.CreatedDate,
                             Description = a.Description,
                             Content = a.Content,
                             AuthorRole = e.Role,
                             Category = b.Name,
                             Avatar = g.FilePath
                         }).First();
            var tags = (from x in _dbContext.PostTagEntities
                        join y in _dbContext.TagEntities on x.TagId equals y.Id
                        where x.PostId == id
                        select y.Name).ToList();
            query.Tag = tags;
            return View(query);
        }

        [HttpGet]
        public IActionResult GetRelatedPost(int id)
        {
            var query = (from a in _dbContext.PostEntities
                         join b in _dbContext.PostImageEntities on a.Id equals b.PostId
                         join c in _dbContext.FileManageEntities on b.FileId equals c.Id
                         where a.IsDeleted == false && a.Id != id && a.Status == 0
                         where b.IsDeleted == false && b.IsAvatar == true
                         orderby a.CreatedDate descending
                         select new PostModel()
                         {
                             Id = a.Id,
                             Title = a.Title,
                             Description = a.Description,
                             Content = a.Content,
                             PostAvatarId = c.Id,
                             PostAvatarFilePath = c.FilePath,
                             CreatedDate = a.CreatedDate,
                             UpdatedDate = a.UpdatedDate,
                             CreatedBy = a.CreatedBy,
                             UpdatedBy = a.UpdatedBy
                         }).ToList().Take(3);
            return Json(query);
        }
    }
}
