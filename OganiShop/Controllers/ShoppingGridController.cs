using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppManager.Controllers
{
    public class ShoppingGridController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ShoppingGridController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class PriceRange
        {
            public int MinPrice { get; set; }
            public int MaxPrice { get; set; }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _dbContext.CategoryEntities;
            return categories.Any() ? Json(categories.ToList()) : Json("");
        }

        [HttpGet]
        public IActionResult FilterProductByPrice(PriceRange priceRange)
        {
            var prd = (from x in _dbContext.ProductImageEntities
                       join y in _dbContext.FileManageEntities on x.FileId equals y.Id
                       join z in _dbContext.ProductEntities on x.ProductId equals z.Id
                       where z.IsDeleted == false
                       where z.Price >= priceRange.MinPrice && z.Price <= priceRange.MaxPrice
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
                       });
            var data = new
            {
                Count = prd.Any() ? prd.Count() : 0,
                ListProduct = prd.Any() ? prd.ToList() : new List<ProductModel>(),
            };
            return Json(data);
        }

        [HttpGet]
        public IActionResult GetAllDiscountProduct()
        {
            var prd = (from a in _dbContext.ProductEntities
                       join b in _dbContext.DiscountEntities on a.Id equals b.ProductId
                       join c in _dbContext.ProductImageEntities on a.Id equals c.ProductId
                       join d in _dbContext.FileManageEntities on c.FileId equals d.Id
                       join e in _dbContext.CategoryEntities on a.CategoryId equals e.Id
                       where a.IsDeleted == false
                       where c.IsAvatar == true && c.IsDeleted == false
                       where b.CreatedDate <= DateTime.Now && b.EndDate >= DateTime.Now
                       select new
                       {
                           Id = a.Id,
                           Name = a.Name,
                           Slug = a.Slug,
                           Price = b.DiscountType == 0 ? (a.Price - b.DiscountValue) : (a.Price * (1 - b.DiscountValue / 100)),
                           OldPrice = a.Price,
                           Category = e.Name,
                           DiscountType = b.DiscountType,
                           DiscountValue = b.DiscountValue,
                           Avatar = d.FilePath,
                           AvatarFileId = d.Id
                       });
            return prd.Any() ? Json(prd.ToList()) : Json("");
        }
    }
}
