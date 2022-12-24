using AppAccountManager.Entities;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ReportController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MonthlyCategoryReport()
        {
            var query = (from c in _dbContext.CategoryEntities
                         join p in _dbContext.ProductEntities on c.Id equals p.CategoryId
                         join a in _dbContext.OrderDetailEntities on p.Id equals a.ProductId
                         join b in _dbContext.ShopOrderEntities on a.ShopOrderId equals b.Id
                         where b.CreatedDate.Month == DateTime.Now.Month
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
                                  .Take(5).ToList();
            return Json(categories);
        }

        public class AnuallyReportModel
        {
            public string Category { get; set; }
            public List<int> Month { get; set; }
        }


        public IActionResult AnnuallyCategoryReport()
        {
            var query = (from c in _dbContext.CategoryEntities
                         join p in _dbContext.ProductEntities on c.Id equals p.CategoryId
                         join a in _dbContext.OrderDetailEntities on p.Id equals a.ProductId
                         join b in _dbContext.ShopOrderEntities on a.ShopOrderId equals b.Id
                         where b.CreatedDate.Year == DateTime.Now.Year
                         select new ProductModel()
                         {
                             Id = c.Id,
                             Name = p.Name,
                             Category = c.Name, 
                             Slug = c.Slug,
                             Quantity = a.Quantity,
                             CreatedDate = a.CreatedDate,
                         }).ToList();
            var categories = (from q in query
                             group q by new { q.Category, q.CreatedDate.Month } into gr
                             select new
                            {
                                Category = gr.Key.Category,
                                Month = gr.Key.Month,
                                Quantity = gr.Sum(x => x.Quantity)
                            }).ToList();
            Dictionary<string, List<int>> result = new Dictionary<string, List<int>>();
            foreach (var category in categories)
            {
                if (!result.ContainsKey(category.Category))
                {
                    var month = categories.Where(x => x.Category == category.Category).ToList();
                    var count = 0;
                    result[category.Category] = Enumerable.Repeat(0, 12).ToList(); ;
                    foreach (var m in month)
                    {
                        result[category.Category][m.Month - 1] = m.Quantity;
                    }
                }
            }
            List<AnuallyReportModel> report = new List<AnuallyReportModel>();
            foreach (var item in result)
            {
                report.Add(new AnuallyReportModel
                {
                    Category = item.Key,
                    Month = item.Value,
                });
            }
            return Json(report);
        }
    }
}
