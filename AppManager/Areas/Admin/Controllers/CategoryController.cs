using AppAccountManager.Entities;
using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin,staff")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _enviroment;

        public CategoryController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _enviroment = environment;
        }

        public IActionResult ListCategory(string name, int pageNumber = 1)
        {
            int pageSize = 5;
            var query = (from c in _dbContext.CategoryEntities
                         join x in _dbContext.FileManageEntities on c.FileId equals x.Id
                         where x.IsDeleted == false
                         where string.IsNullOrEmpty(name) || c.Name.ToLower().Contains(name.Trim().ToLower())
                         select new CategoryModel()
                         {
                            Id = c.Id,
                            Name = c.Name,
                            Slug = c.Slug,
                            FileId = c.FileId,
                            FilePath = x.FilePath
                         }).ToList();
            var total = query.Count();
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.name = name;
            var listCategory = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            return View(listCategory);
        }

        public IActionResult AddOrUpdate(int id)
        {
            if (id > 0)
            {
                var category = _dbContext.CategoryEntities.Find(id);
                var imagePath = _dbContext.FileManageEntities.Find(category.FileId).FilePath;
                return View(new CategoryModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Slug = category.Slug,
                    FileId = category.FileId,
                    FilePath = imagePath
                });
            }
            else
            {
                return View(new CategoryModel());
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(CategoryModel category)
        {
            if (category.Id == 0)
            {
                _dbContext.CategoryEntities.Add(new CategoryEntity()
                {
                    Name = category.Name,
                    FileId = category.FileId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                }); 
            }
            else
            {
                var entity = _dbContext.CategoryEntities.Find(category.Id);
                entity.Name = category.Name;
                entity.FileId = category.FileId;
                _dbContext.CategoryEntities.Update(entity);
            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Category/ListCategory");
        }

        public IActionResult Delete(int id)
        {
            var entity = _dbContext.CategoryEntities.Find(id);
            entity.IsDeleted = true;
            _dbContext.CategoryEntities.Update(entity);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Category/ListCategory");
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null)
            {
                return Json(new { status = "error" });
            }
            string folderUploads = Path.Combine(_enviroment.WebRootPath, "img\\category");
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var fileEntity = new FileManageEntity()
            {
                Name = file.Name,
                FilePath = "/img/category/" + fileName,
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
    }
}
