using AppAccountManager.Entities;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAccount()
        {
            string account = "";
            try{
                var claims = HttpContext.User.Identity as ClaimsIdentity;
                account = claims.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            catch(Exception ex)
            {
                return Json("");
            }
            var user = _dbContext.UserEntities.First(x => x.Account == account);
            string username = user.FirstName + " " + user.LastName;
            return Json(username);
        }

        public IActionResult Index()
        {
            //var products = _dbContext.ProductEntities.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _dbContext.CategoryEntities.ToList();
            return categories != null ? Json(categories) : Json("");
        }

        [HttpGet]
        public IActionResult GetHeaderBanner()
        {
            var banner = (from b in _dbContext.BannerEntities
                          join f in _dbContext.FileManageEntities on b.FileId equals f.Id
                          where b.Type == 0
                          select new BannerModel()
                          {
                              Id = b.Id,
                              ImagePath = f.FilePath,
                          }).FirstOrDefault();
            return banner != null ? Json(banner) : Json("");
        }

        [HttpGet]
        public IActionResult GetAllCategoryImage()
        {
            var categoryImg = (from b in _dbContext.CategoryEntities
                               join f in _dbContext.FileManageEntities on b.FileId equals f.Id
                               select new CategoryRenderModel()
                               {
                                   Id = b.Id,
                                   Name = b.Name,
                                   Slug = b.Slug,
                                   FileId = f.Id,
                                   FilePath = f.FilePath,
                               }).ToList();
            return categoryImg != null ? Json(categoryImg) : Json("");
        }

        [HttpGet]
        public IActionResult GetAllFeature()
        {
            var x = _dbContext.CategoryEntities.Select(x => x).ToList();
            var query = (from c in _dbContext.CategoryEntities
                         join p in _dbContext.ProductEntities on c.Id equals p.CategoryId
                         join a in _dbContext.OrderDetailEntities on p.Id equals a.ProductId
                         join b in _dbContext.ShopOrderEntities on a.ShopOrderId equals b.Id
                         select new
                         {
                             Id = c.Id,
                             Name = c.Name,
                             Slug = c.Slug,
                             ProductId = a.ProductId,
                             Quantity = a.Quantity,
                         });
            var categories = query.GroupBy(item => new { item.Id, item.Name, item.Slug })
                                  .Select(item => new
                                  {
                                      Id = item.Key.Id,
                                      Name = item.Key.Name,
                                      Slug = item.Key.Slug,
                                      Quantity = item.Sum(x => x.Quantity)
                                  })
                                  .OrderByDescending(item => item.Quantity)
                                  .ToList().Take(5);
            List<CategoryProductModel>listCategories = new List<CategoryProductModel>();
            int maxStore = 8;
            foreach (var category in categories)
            {
                var q = (from a in _dbContext.ProductEntities
                               join b in _dbContext.CategoryEntities on a.CategoryId equals b.Id
                               join c in _dbContext.OrderDetailEntities on a.Id equals c.ProductId
                               join d in _dbContext.ProductImageEntities on a.Id equals d.ProductId
                               join e in _dbContext.FileManageEntities on d.FileId equals e.Id
                               where a.IsDeleted == false
                               where b.IsDeleted == false && b.Id == category.Id
                               where c.IsDeleted == false
                               where d.IsAvatar == true
                               select new ProductModel()
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Price = a.Price,
                                   Avatar = e.FilePath,
                                   AvatarFileId = e.Id,
                                   Quantity = c.Quantity,
                               }).ToList();
                var list = (from a in q
                              group a by new { a.Id, a.Name, a.Avatar, a.AvatarFileId, a.Price} into item
                              select new ProductModel()
                              {
                                    Id = item.Key.Id,
                                    Name = item.Key.Name,
                                    Price= item.Key.Price,
                                    Avatar = item.Key.Avatar,
                                    AvatarFileId = item.Key.AvatarFileId,
                                    Quantity = item.Sum(a => a.Quantity),
                              }).OrderByDescending(x => x.Quantity).ToList();
                int take = list.Count <= maxStore ? list.Count : maxStore;
                maxStore -= take;
                var listPrd = list.Take(take).ToList();
                listCategories.Add(new CategoryProductModel()
                {
                    CategoryId = category.Id,
                    CategorySlug = category.Slug,
                    CategoryName = category.Name,
                    ListProduct = listPrd
                });
            }
            return Json(listCategories);
        }

        [HttpGet]
        public IActionResult GetSmallBanner()
        {
            var banner = (from b in _dbContext.BannerEntities
                          join f in _dbContext.FileManageEntities on b.FileId equals f.Id
                          where b.Type == 1
                          select new BannerModel()
                          {
                              Id = b.Id,
                              ImagePath = f.FilePath,
                          });
            return banner != null ? Json(banner) : Json("");
        }

        [HttpGet]
        public IActionResult GetLatestProducts()
        {
            var latestProducts = (from b1 in _dbContext.ProductEntities
                                  join b2 in _dbContext.ProductImageEntities on b1.Id equals b2.ProductId
                                  join b3 in _dbContext.FileManageEntities on b2.FileId equals b3.Id
                                  where !(bool)b1.IsDeleted && (bool)b2.IsAvatar && !(bool)b2.IsDeleted
                                  orderby b1.CreatedDate descending
                                  select new ProductModel()
                                  {
                                      Id = b1.Id,
                                      Name = b1.Name,
                                      Slug = b1.Slug,
                                      Price = b1.Price,
                                      OldPrice = b1.OldPrice,
                                      Description = b1.Description,
                                      Summary = b1.Summary,
                                      Quantity = b1.Quantity,
                                      Weight = b1.Weight,
                                      Unit = b1.Unit,
                                      CategoryId = b1.CategoryId,
                                      Avatar = b3.FilePath,
                                      AvatarFileId = b3.Id
                                  }).Take(9).ToList();
            return Json(latestProducts);
        }
    }
}
