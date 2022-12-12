using AppAccountManager.Entities;
using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AppManager.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductDetailController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class ProductDetailModel
        {
            public ProductModel Info { get; set; }
            public List<ProductImageModel> ListImages { get; set; }
        }
        public IActionResult Product(int id)
        {
            var prd = (from x in _dbContext.ProductImageEntities
                       join y in _dbContext.FileManageEntities on x.FileId equals y.Id
                       join z in _dbContext.ProductEntities on x.ProductId equals z.Id
                       where z.Id == id && z.IsDeleted == false
                       where x.IsAvatar == true && x.IsDeleted == false
                       orderby z.Id ascending
                       select new ProductModel()
                       {
                           Id = z.Id,
                           Name = z.Name,
                           Slug = z.Slug,
                           Price = z.Price,
                           OldPrice = z.OldPrice,
                           Description = z.Description,
                           Summary = z.Summary,
                           Quantity = z.Quantity,
                           Weight = z.Weight,
                           Unit = z.Unit,
                           CategoryId = z.CategoryId,
                           Avatar = y.FilePath,
                           AvatarFileId = y.Id
                       }).First();
            var img = (from x in _dbContext.ProductImageEntities
                       join y in _dbContext.FileManageEntities on x.FileId equals y.Id
                       where x.IsDeleted == false && x.ProductId == id
                       orderby x.Id ascending
                       select new ProductImageModel()
                       {
                           Id = x.Id,
                           ProductId = id,
                           FileId = y.Id,
                           FilePath = y.FilePath,
                           IsAvatar = x.IsAvatar
                       }).ToList();
            return View(new ProductDetailModel()
            {
                Info = prd,
                ListImages = img
            });
        }

        [HttpGet]
        public IActionResult GetRelatedProduct(int id)
        {
            var prd = (from x in _dbContext.ProductImageEntities
                       join y in _dbContext.FileManageEntities on x.FileId equals y.Id
                       join z in _dbContext.ProductEntities on x.ProductId equals z.Id
                       where z.Id != id && z.IsDeleted == false
                       where x.IsAvatar == true && x.IsDeleted == false
                       orderby z.Id ascending
                       select new ProductModel()
                       {
                           Id = z.Id,
                           Name = z.Name,
                           Slug = z.Slug,
                           Price = z.Price,
                           OldPrice = z.OldPrice,
                           Description = z.Description,
                           Summary = z.Summary,
                           Quantity = z.Quantity,
                           Weight = z.Weight,
                           Unit = z.Unit,
                           CategoryId = z.CategoryId,
                           Avatar = y.FilePath,
                           AvatarFileId = y.Id
                       }).Take(4).ToList();
            return Json(prd);
        }
    }
}
