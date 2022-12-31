using AppAccountManager.Entities;
using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin,staff")]
    public class ShopOrderController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ShopOrderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult ListOrder(int pageNumber = 1)
        {
            int pageSize = 5;
            var query = (from a in _dbContext.ShopOrderEntities
                         join b in _dbContext.AccountManagerEntities on a.Account equals b.Account into tbl
                         from t in tbl.DefaultIfEmpty()
                         where a.IsDeleted == false
                         select new ShopOrderModel()
                         {
                             ShopOrderId = a.Id,
                             OrderStatus = a.OrderStatus,
                             TotalPrice = a.TotalPrice,
                             Account = t.Account == null ? null : a.Account,
                             CreatedDate = a.CreatedDate,
                         }).ToList();
            var total = query.Count();
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            var listCategory = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            return View(query);
        }

        public class OrderInfo
        {
            public ShopOrderModel ShopOrder { get; set; }
            public List<OrderDetailModel> ListOrderDetail { get; set; }
        }

        public IActionResult OrderDetail(int id)
        {
            var order = (from a in _dbContext.ShopOrderEntities
                         join b in _dbContext.AccountManagerEntities on a.Account equals b.Account into tbl
                         from t in tbl.DefaultIfEmpty()
                         where a.IsDeleted == false
                         where a.Id == id
                         select new ShopOrderModel()
                         {
                             ShopOrderId = a.Id,
                             OrderStatus = a.OrderStatus,
                             TotalPrice = a.TotalPrice,
                             Account = t.Account == null ? null : a.Account,
                             CreatedDate = a.CreatedDate,
                         }).First();
            var orderDetail = (from a in _dbContext.ShopOrderEntities
                               join b in _dbContext.OrderDetailEntities on a.Id equals b.ShopOrderId
                               join c in _dbContext.ProductEntities on b.ProductId equals c.Id
                               where a.IsDeleted == false && b.IsDeleted == false
                               where a.Id == id
                               select new OrderDetailModel()
                               {
                                   ShopOrderId = a.Id,
                                   ProductId = b.ProductId,
                                   ProductName = c.Name,
                                   Quantity = b.Quantity,
                                   Price = b.Price,
                                   TotalPrice = b.TotalPrice
                               }).ToList();
            return View(new OrderInfo()
            {
                ShopOrder = order,
                ListOrderDetail = orderDetail,
            });
        }
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.ShopOrderEntities.Find(id);
            entity.IsDeleted = true;
            _dbContext.ShopOrderEntities.Update(entity);
            var detail = _dbContext.OrderDetailEntities.Where(x => x.ShopOrderId == id).ToList();
            foreach (var item in detail)
            {
                item.IsDeleted = true;
                _dbContext.OrderDetailEntities.Update(item);
            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Product/ListProduct");
        }
    }
}
