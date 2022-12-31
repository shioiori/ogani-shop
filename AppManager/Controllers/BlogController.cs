using AppAccountManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AppManager.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BlogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // asp.net k chấp nhận overloading

        [HttpGet]
        public IActionResult Index(string arg, int pageNumber = 1)
        {
            int pageSize = 6;
            if (Int32.TryParse(arg, out int r))
            {
                var query = (from a in _dbContext.PostEntities
                             join b in _dbContext.PostImageEntities on a.Id equals b.PostId
                             join c in _dbContext.FileManageEntities on b.FileId equals c.Id
                             join d in _dbContext.CategoryBlogEntities on a.CategoryId equals d.Id
                             where a.IsDeleted == false && a.Status == 0
                             where b.IsDeleted == false && b.IsAvatar == true
                             where d.Id == r
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
                             }).ToList();
                int total = query.Count();
                ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
                ViewBag.pageNumber = pageNumber;
                ViewBag.pageSize = pageSize;
                ViewBag.arg = arg;
                return View(query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList());
            }
            else if (arg != null)
            {
                var query = (from a in _dbContext.PostEntities
                             join b in _dbContext.PostImageEntities on a.Id equals b.PostId
                             join c in _dbContext.FileManageEntities on b.FileId equals c.Id
                             join d in _dbContext.PostTagEntities on a.Id equals d.PostId
                             join e in _dbContext.TagEntities on d.TagId equals e.Id
                             where a.IsDeleted == false && a.Status == 0
                             where b.IsDeleted == false && b.IsAvatar == true
                             where d.IsDeleted == false
                             where e.IsDeleted == false && e.Slug == arg
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
                             }).ToList();
                int total = query.Count();
                ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
                ViewBag.pageNumber = pageNumber;
                ViewBag.pageSize = pageSize;
                ViewBag.arg = arg;
                return View(query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList());
            }
            else
            {
                var query = (from a in _dbContext.PostEntities
                             join b in _dbContext.PostImageEntities on a.Id equals b.PostId
                             join c in _dbContext.FileManageEntities on b.FileId equals c.Id
                             where a.IsDeleted == false && a.Status == 0
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
                             }).ToList();
                int total = query.Count();
                ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
                ViewBag.pageNumber = pageNumber;
                ViewBag.pageSize = pageSize;
                ViewBag.arg = arg;
                return View(query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList());
            }
        }

        [HttpGet]
        public IActionResult GetCategoryBlog()
        {
            var query = _dbContext.CategoryBlogEntities.Where(x => x.IsDeleted == false);
            return !query.Any() ? Json("") : Json(query.ToList());
        }

        [HttpGet]
        public IActionResult GetRecentNews()
        {
            var query = (from a in _dbContext.PostEntities
                         join b in _dbContext.PostImageEntities on a.Id equals b.PostId
                         join c in _dbContext.FileManageEntities on b.FileId equals c.Id
                         where a.IsDeleted == false && a.Status == 0 
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
                         });
            return !query.Any() ? Json("") : Json(query.ToList().Take(3));
        }

        [HttpGet]
        public IActionResult GetAllTags()
        {
            var query = _dbContext.TagEntities.Where(x => x.IsDeleted == false);
            return query.Any() ? Json(query.ToList()) : Json("");
        }

    }
}
