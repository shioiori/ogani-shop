using AppAccountManager.Entities;
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

        [HttpGet]
        public IActionResult Index(string name, int category, int minprice = -1, int maxprice = -1, int pageNumber = 1)
        {
            var discount = (from a in _dbContext.ProductEntities
                       join b in _dbContext.DiscountEntities on a.Id equals b.ProductId
                       join c in _dbContext.ProductImageEntities on a.Id equals c.ProductId
                       join d in _dbContext.FileManageEntities on c.FileId equals d.Id
                       join e in _dbContext.CategoryEntities on a.CategoryId equals e.Id
                       where a.IsDeleted == false
                       where c.IsAvatar == true && c.IsDeleted == false
                       where b.CreatedDate <= DateTime.Now && b.EndDate >= DateTime.Now
                       where e.Id == category || category == 0
                       where minprice == -1 || (a.Price >= minprice && a.Price <= maxprice)
                       where string.IsNullOrEmpty(name) || a.Name.Contains(name.ToLower())
                       select new ProductDiscountModel()
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
                       }).ToList();
            var prd = (from x in _dbContext.ProductImageEntities
                       join y in _dbContext.FileManageEntities on x.FileId equals y.Id
                       join z in _dbContext.ProductEntities on x.ProductId equals z.Id
                       join w in _dbContext.CategoryEntities on z.CategoryId equals w.Id
                       where z.IsDeleted == false
                       where w.Id == category || category == 0
                       where x.IsAvatar == true && x.IsDeleted == false
                       where minprice == -1 || (z.Price >= minprice && z.Price <= maxprice)
                       where string.IsNullOrEmpty(name) || z.Name.Contains(name.ToLower())
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
                       }).ToList();
            var temp = new List<ProductModel>(prd);
            foreach(var item in temp)
            {
                if (discount.Any(x => x.Id == item.Id))
                {
                    prd.Remove(item);
                }
            }
            int pageSize = 12;
            int total = prd.Count();
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.category = category;
            ViewBag.minprice = minprice;
            ViewBag.maxprice = maxprice;
            var data = new ShoppingGridModel()
            {
                Discount = discount.Any() ? discount.Take(10).ToList() : new List<ProductDiscountModel>(),
                Count = prd.Any() ? prd.Count() : 0,
                ListProduct = prd.Any() ? prd.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList() : new List<ProductModel>(),
            };
            return View(data);
        }

        public class ShoppingGridModel
        {
            public List<ProductDiscountModel> Discount { get; set; }
            public int Count { get; set; }
            public List<ProductModel> ListProduct { get; set; }
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _dbContext.CategoryEntities;
            return categories.Any() ? Json(categories.ToList()) : Json("");
        }
    }
}
