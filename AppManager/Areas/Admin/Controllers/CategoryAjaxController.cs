using AppAccountManager.Entities;
using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryAjaxController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryAjaxController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetData([FromBody]RequestModel req)
        {
            var query = _dbContext.CategoryEntities.Where(x => !(bool)x.IsDeleted);
            if (!string.IsNullOrEmpty(req.FreeText))
            {
                query = query.Where(x => x.Name.ToLower().Contains(req.FreeText));
            }
            var res = new ResponseModel<CategoryModel>();
            int skip = req.PageSize * req.PageNumber - req.PageSize;
            res.TotalCount = query.Count();
            res.Data = query.Select(x => new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
            }).Skip(skip).Take(req.PageSize).ToList();
            return Json(res);
        }
        [HttpPost]
        public IActionResult AddOrUpdate([FromBody]CategoryModel model)
        {
            if (model.Id == 0)
            {
                var entity = new CategoryEntity()
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    CreatedBy = "na",
                    UpdatedBy = "na",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                _dbContext.CategoryEntities.Add(entity);
            }
            else
            {
                var entity = _dbContext.CategoryEntities.Find(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Slug = model.Slug;   
                    entity.CreatedDate = DateTime.Now;
                    _dbContext.CategoryEntities.Update(entity);
                }
            }
            var status = _dbContext.SaveChanges();
            return Json(status);
        }
    }
}
