using AppAccountManager.Entities;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AppManager.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ShoppingCartController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var account = HttpContext.Request.Cookies["account"];
            var x = (from a in _dbContext.ProductEntities
                     join b in _dbContext.DiscountEntities on a.Id equals b.ProductId into tbl
                     from t in tbl.DefaultIfEmpty()
                     where a.IsDeleted == false
                     select new ProductModel()
                     {
                         Id = a.Id,
                         Name = a.Name,
                         Slug = a.Slug,
                         Price = (t.CreatedDate <= DateTime.Now && t.EndDate >= DateTime.Now)
                                 ? (t.DiscountType == 0 ? (a.Price - t.DiscountValue) : (a.Price * (1 - t.DiscountValue / 100)))
                                 : a.Price,
                     });
            // xài tolist cho x thì lỗi như một trò đùa????
            var cart = (from a in x
                        join c in _dbContext.ProductImageEntities on a.Id equals c.ProductId
                        join d in _dbContext.FileManageEntities on c.FileId equals d.Id
                        join e in _dbContext.ShoppingCartEntities on a.Id equals e.ProductId
                        where e.IsDeleted == false
                        where c.IsAvatar == true && c.IsDeleted == false
                        where e.Customer == account && e.Status == 0
                        select new ProductModel()
                        {
                            Id = a.Id,
                            CartId = e.Id,
                            Name = a.Name,
                            Slug = a.Slug,
                            Price = a.Price,
                            Quantity = e.Quantity,
                            Avatar = d.FilePath,
                            AvatarFileId = d.Id
                        }).ToList();
            return cart.Any() ? View(cart.ToList()) : View(new List<ProductModel>());
        }


        [HttpGet]
        public IActionResult AddItemToCart(int id, int quantity = -1)
        {
            // kiếm xem có đăng nhập chưa
            var account = HttpContext.Request.Cookies["account"];
            // nếu claim khác null
            if (account == null)
            {
                // sinh guid ra 1 user tạm thời nhưng k có thông tin ng này trong db
                account = Guid.NewGuid().ToString();
                HttpContext.Response.Cookies.Append("account", account);
            }
            // tìm xem trong giỏ hàng có sản phẩm này không
            var cart = _dbContext.ShoppingCartEntities.Where(x => x.ProductId == id && x.Customer == account && x.Status == 0)
                                                      .Select(x => new ShoppingCartEntity()
                                                        {
                                                            Id = x.Id,
                                                            ProductId = x.ProductId,
                                                            Quantity = x.Quantity,
                                                            CreatedDate = x.CreatedDate,
                                                            UpdatedDate = x.UpdatedDate,
                                                            Customer = account
                                                        });
            if (cart.Any())
            {
                // nếu có thì update sl của sản phẩm này thêm 1
                var item = cart.Select(x => new ShoppingCartEntity()
                {
                    Id = x.Id,
                    ProductId = id,
                    Quantity = quantity == -1 ? x.Quantity + 1 : quantity,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = DateTime.Now,
                    Customer = x.Customer
                }).First();
                _dbContext.ShoppingCartEntities.Update(item);
            }
            else
            {
                // k có thì add cái mới
                _dbContext.ShoppingCartEntities.Add(new ShoppingCartEntity()
                {
                    ProductId = id,
                    Quantity = quantity == -1 ? 1 : quantity,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Customer = account
                });
            }
            _dbContext.SaveChanges();
            return Json("ok!"); 
        }

        // tạm đang thay đổi truyền bằng model thay ajax nên hàm này chưa xài
        public IActionResult GetItemInCart()
        {
            var x = (from a in _dbContext.ProductEntities
                    join b in _dbContext.DiscountEntities on a.Id equals b.ProductId into tbl
                    from t in tbl.DefaultIfEmpty()
                    where a.IsDeleted == false
                    select new
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Slug = a.Slug,
                        Price = (t.CreatedDate <= DateTime.Now && t.EndDate >= DateTime.Now) 
                                ? (t.DiscountType == 0 ? (a.Price - t.DiscountValue) : (a.Price * (1 - t.DiscountValue / 100)))
                                : a.Price,
                    }).ToList();

            var account = HttpContext.Request.Cookies["account"];
            var cart = (from a in x
                        join c in _dbContext.ProductImageEntities on a.Id equals c.ProductId
                        join d in _dbContext.FileManageEntities on c.FileId equals d.Id
                        join e in _dbContext.ShoppingCartEntities on a.Id equals e.ProductId
                        where e.IsDeleted == false
                        where c.IsAvatar == true && c.IsDeleted == false
                        where e.Customer == account && e.Status == 0
                        select new ProductModel()
                        {
                            Id = a.Id,
                            CartId = e.Id,
                            Name = a.Name,
                            Slug = a.Slug,
                            Price = a.Price,
                            Quantity = e.Quantity,
                            Avatar = d.FilePath,
                            AvatarFileId = d.Id
                        });
            return cart.Any() ? Json(cart) : Json("");
        }
        
        [HttpGet]
        public IActionResult RemoveProduct(int id)
        {
            var cart = _dbContext.ShoppingCartEntities.Find(id);
            cart.IsDeleted = true;
            cart.Status = 1;
            _dbContext.ShoppingCartEntities.Update(cart);
            _dbContext.SaveChanges();
            return Redirect("/ShoppingCart/Index");
        }

    }
}
