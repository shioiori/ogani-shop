using AppAccountManager.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppManager.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using AppManager.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public BlogController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult AuthorInfo()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var account = claims.FindFirst(ClaimTypes.NameIdentifier).Value;
            var query = (from a in _dbContext.AccountManagerEntities
                         join b in _dbContext.AccountImageEntities on a.Account equals b.Account
                         join c in _dbContext.FileManageEntities on b.FileId equals c.Id
                         join d in _dbContext.UserEntities on a.Account equals d.Account
                         where a.Account == account
                         select new PostDetailModel()
                         {
                             AuthorName = d.FirstName + " " + d.LastName,
                             AuthorRole = a.Role,
                             Avatar = c.FilePath,
                         }).First();
            return Json(query);
        }
        public IActionResult AddOrUpdate(int id)
        {
            var query = (from a in _dbContext.PostEntities
                         join b in _dbContext.CategoryBlogEntities on a.CategoryId equals b.Id
                         join e in _dbContext.AccountManagerEntities on a.CreatedBy equals e.Account
                         join f in _dbContext.PostImageEntities on a.Id equals f.PostId
                         join g in _dbContext.FileManageEntities on f.FileId equals g.Id
                         join h in _dbContext.UserEntities on e.Account equals h.Account
                         where a.IsDeleted == false
                         where a.Id == id || id == 0
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
                             CategoryId = b.Id,
                             Category = b.Name,
                             Avatar = g.FilePath,
                             AvatarId = g.Id,
                         }).First();
            var tags = (from x in _dbContext.PostTagEntities
                        join y in _dbContext.TagEntities on x.TagId equals y.Id
                        where x.PostId == id || id == 0
                        select y.Name).ToList();
            query.Tag = tags;
            return id == 0 ? View() : View(query);
        }

        [HttpPost]
        public IActionResult AddOrUpdate(PostDetailModel model)
        {
            if (model.Id == 0)
            {
                TempData["Alert"] = "Đã thêm bài viết mới thành công!";
            }
            else
            {
                TempData["Alert"] = "Đã sửa bài viết thành công!";
            }

            // lấy tên tk
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var account = claims.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            // thêm bài viết
     
            var entity = _dbContext.PostEntities.Find(model.Id);
            if (entity == null)
            {
                entity = new PostEntity()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content,
                    CategoryId = model.CategoryId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = account,
                    UpdatedBy = account,
                    Status = model.Status,
                };
                _dbContext.PostEntities.Add(entity);
                
            }
            else
            {
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Content = model.Content;
                entity.CategoryId = model.CategoryId;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = account;
                entity.Status = model.Status;
                _dbContext.PostEntities.Update(entity);
            }
            _dbContext.SaveChanges();
            model.Id = entity.Id;
            // thêm ảnh đại diện ?? select x=>x k dc nhưng select new thì dc
            var img = _dbContext.PostImageEntities.Where(x => x.PostId == model.Id && x.IsAvatar == true)
                                                  .Select(x => new PostImageEntity()
                                                  {
                                                      Id = x.Id,
                                                      PostId = x.PostId,
                                                      FileId = x.FileId,
                                                      IsAvatar = x.IsAvatar,
                                                      CreatedDate = x.CreatedDate,
                                                      UpdatedDate = x.UpdatedDate,
                                                      CreatedBy = x.CreatedBy,
                                                      UpdatedBy = x.UpdatedBy,
                                                  }).ToList();
            // xoá avatar cũ
            if (img.Any())
            {
                var avatar = img.First();
                avatar.IsAvatar = false;
                avatar.UpdatedDate = DateTime.Now;
                avatar.UpdatedBy = account;
                _dbContext.PostImageEntities.Update(avatar);
            }
            // thêm avatar mới
            _dbContext.PostImageEntities.Add(new PostImageEntity()
            {
                PostId = model.Id,
                FileId = model.AvatarId,
                IsAvatar = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = account,
                UpdatedBy = account,
            });
            _dbContext.SaveChanges();


            // thêm tag mới vào entity tag
            var tags = model.Tag[0].ToString().Split(",").ToList();
            foreach (var tag in tags)
            {
                if (!_dbContext.TagEntities.Where(x => x.Name == tag).Any())
                {
                    var e = new TagEntity()
                    {
                        Name = tag,
                        Slug = tag.Replace(" ", "-").ToLower(),
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CreatedBy = account,
                        UpdatedBy = account,
                    };
                    _dbContext.TagEntities.Add(e);
                    _dbContext.SaveChanges();
                    _dbContext.PostTagEntities.Add(new PostTagEntity()
                    {
                        PostId = model.Id,
                        TagId = e.Id,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CreatedBy = account,
                        UpdatedBy = account,
                    });
                    _dbContext.SaveChanges();
                }
            }
            // xoá tag k có trong bài
            var q = (from a in _dbContext.PostTagEntities
                    join b in _dbContext.TagEntities on a.TagId equals b.Id
                    where a.PostId == model.Id && a.IsDeleted == false
                    select new TagModel()
                    {
                        Id = b.Id,
                        Slug = b.Slug,
                        Name = b.Name,
                    }).ToList();
            foreach(var item in q)
            {
                if (!tags.Contains(item.Name))
                {
                    var pt = _dbContext.PostTagEntities.Where(x => x.TagId == item.Id && x.PostId == model.Id)
                                                      .Select(x => x)
                                                      .First();
                    pt.IsDeleted = true;
                    pt.UpdatedBy = account;
                    pt.UpdatedDate = DateTime.Now;
                    _dbContext.PostTagEntities.Update(pt);
                    _dbContext.SaveChanges();
                }
            }

            // thêm tag còn lại vào trong bài
            foreach (var tag in tags)
            {
                var id = _dbContext.TagEntities.Where(x => x.Name == tag).Select(x => x.Id).First();
                var pt = _dbContext.PostTagEntities.Where(x => x.TagId == id && x.PostId == model.Id && x.IsDeleted == false).Select(x => x);
                if (!pt.Any())
                {
                    var e = new PostTagEntity()
                    {
                        PostId = model.Id,
                        TagId = id,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CreatedBy = account,
                        UpdatedBy = account,
                    };
                    _dbContext.PostTagEntities.Add(e);
                }            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Blog/AddOrUpdate?id=" + entity.Id);
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            //up avatar bài post

            if (file == null)
            {
                return Json(new { status = "error" });
            }
            string folderUploads = Path.Combine(_environment.WebRootPath, "img\\blog\\avatar");
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var fileEntity = new FileManageEntity()
            {
                Name = file.Name,
                FilePath = "/img/blog/avatar/" + fileName,
                FileType = "image",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _dbContext.FileManageEntities.Add(fileEntity);
            var status = _dbContext.SaveChanges();
            if (status == 0)
            {
                return Json(new { status = "error" });
            }
            var model = new FileModel()
            {
                Id = fileEntity.Id,
                Name = fileEntity.Name,
                FilePath = fileEntity.FilePath
            };
            return Json(new
            {
                status = "success",
                fileInfo = model
            });
        }

        public IActionResult YourPost(string name, int status = -1, int pageNumber = 1)
        {
            // status = 0 - công khai, 1 - bản nháp, 2 - xoá, all = -1
            var account = HttpContext.Request.Cookies["account"];
            var query = (from a in _dbContext.PostEntities
                         join b in _dbContext.CategoryBlogEntities on a.CategoryId equals b.Id
                         join c in _dbContext.PostImageEntities on a.Id equals c.PostId
                         join e in _dbContext.AccountManagerEntities on a.CreatedBy equals e.Account
                         join g in _dbContext.FileManageEntities on c.FileId equals g.Id
                         join h in _dbContext.UserEntities on e.Account equals h.Account
                         where string.IsNullOrEmpty(name) || a.Title.ToLower().Contains(name.Trim().ToLower())
                         where a.IsDeleted == false
                         where a.Status == status || status == -1
                         where c.IsDeleted == false && c.IsAvatar == true
                         where a.CreatedBy == account
                         select new PostDetailModel()
                         {
                             Id = a.Id,
                             Title = a.Title,
                             AuthorName = h.FirstName + " " + h.LastName,
                             CreatedDate = a.CreatedDate,
                             Description = a.Description,
                             Content = a.Content,
                             AuthorRole = e.Role,
                             CategoryId = b.Id,
                             Category = b.Name,
                             Avatar = g.FilePath,
                             Status = status,
                         });
            var total = query.Count();
            int pageSize = 5;
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.name = name;
            ViewBag.status = status;
            var q = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            return total > 0 ? View(q) : View(new List<PostDetailModel>());
        }

        public IActionResult Index(int arg, string name, int pageNumber = 1)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var account = claims.FindFirst(ClaimTypes.NameIdentifier).Value;
            TempData["Account"] = account;

            var query = (from a in _dbContext.PostEntities
                         join b in _dbContext.CategoryBlogEntities on a.CategoryId equals b.Id
                         join c in _dbContext.PostImageEntities on a.Id equals c.PostId
                         join e in _dbContext.AccountManagerEntities on a.CreatedBy equals e.Account
                         join g in _dbContext.FileManageEntities on c.FileId equals g.Id
                         join h in _dbContext.UserEntities on e.Account equals h.Account
                         where string.IsNullOrEmpty(name) || a.Title.ToLower().Contains(name.Trim().ToLower())
                         where a.IsDeleted == false && a.Status == 0
                         where c.IsDeleted == false && c.IsAvatar == true
                         where b.Id == arg || arg == 0
                         select new PostDetailModel()
                         {
                             Id = a.Id,
                             Title = a.Title,
                             AuthorName = h.FirstName + " " + h.LastName,
                             CreatedDate = a.CreatedDate,
                             Description = a.Description,
                             Content = a.Content,
                             AuthorRole = e.Role,
                             CategoryId = b.Id,
                             Category = b.Name,
                             Avatar = g.FilePath,
                             Account = e.Account,
                         });
            var total = query.Count();
            int pageSize = 5;
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.name = name;
            var q = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            return total > 0 ? View(q) : View(new List<PostDetailModel>());
        }

        public IActionResult Post(int id)
        {
            var query = (from a in _dbContext.PostEntities
                         join b in _dbContext.CategoryBlogEntities on a.CategoryId equals b.Id
                         join e in _dbContext.AccountManagerEntities on a.CreatedBy equals e.Account
                         join f in _dbContext.PostImageEntities on a.Id equals f.PostId
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
                             CategoryId = b.Id,
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

        public IActionResult Delete(int id)
        {
            var entity = _dbContext.PostEntities.Find(id);
            entity.IsDeleted = true;
            _dbContext.PostEntities.Update(entity);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Blog/Index");
        }
    }
}
