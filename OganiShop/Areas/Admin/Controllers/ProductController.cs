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
using System.Security.Claims;

namespace AppManager.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin, staff")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public ProductController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.Account = accClaim.Value;
            return View();
        }

        public IActionResult ListProduct(string name, int pageNumber = 1)
        {
            int pageSize = 10;

            var query = (from x in _dbContext.ProductImageEntities
                    join y in _dbContext.FileManageEntities on x.FileId equals y.Id
                    join z in _dbContext.ProductEntities on x.ProductId equals z.Id
                    where string.IsNullOrEmpty(name) || z.Name.ToLower().Contains(name.Trim().ToLower())
                    where z.IsDeleted == false
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
                    }).ToList();
            var total = query.Count();
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.name = name;
            var listProduct = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            return View(listProduct);
        }

        public IActionResult AddOrUpdate(int id)
        {
            ViewBag.Category = _dbContext.CategoryEntities.Select(x => new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            if (id > 0)
            {
                var product = _dbContext.ProductEntities.Where(x => x.Id == id)
                                                        .Select(x => new ProductModel()
                                                        {
                                                            Id = x.Id,
                                                            Name = x.Name,
                                                            Price = x.Price,
                                                            OldPrice = x.Price,
                                                            Description = x.Description,
                                                            Summary = x.Summary,
                                                            Quantity = x.Quantity,
                                                            Weight = x.Weight,
                                                            Unit = x.Unit,
                                                            CategoryId = x.CategoryId
                                                        }).First();
                var avatar = (from x in _dbContext.ProductImageEntities
                             join y in _dbContext.FileManageEntities on x.FileId equals y.Id
                             where x.ProductId == product.Id && x.IsAvatar == true
                             select new ProductImageModel()
                             {
                                Id = x.Id,
                                ProductId = x.ProductId,
                                FileId = x.FileId,
                                FilePath = y.FilePath,
                                IsAvatar = x.IsAvatar
                             }).First();
                return View(new ProductModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    OldPrice = product.Price,
                    Description = product.Description,
                    Summary = product.Summary,
                    Quantity = product.Quantity,
                    Weight = product.Weight,
                    Unit = product.Unit,
                    CategoryId = product.CategoryId,
                    Avatar = avatar.FilePath,
                    AvatarFileId = avatar.FileId
                });
            }
            else
            {     
                return View(new ProductModel());
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(ProductModel productModel)
        {
            if (productModel.Id == 0)
            {
                // nếu k có categoryid nghĩa là người dùng auto để giá trị mặc định đầu tiên của cate
                if (productModel.CategoryId == 0)
                {
                    productModel.CategoryId = 1;
                }
                var prd = new ProductEntity()
                {
                    Name = productModel.Name,
                    Price = productModel.Price,
                    OldPrice = productModel.OldPrice,
                    Description = productModel.Description,
                    Summary = productModel.Summary,
                    Quantity = productModel.Quantity,
                    Weight = productModel.Weight,
                    Unit = productModel.Unit,
                    CategoryId = productModel.CategoryId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _dbContext.ProductEntities.Add(prd);
                _dbContext.SaveChanges();
                productModel.Id = prd.Id;
            }
            else
            {
                var entity = _dbContext.ProductEntities.Where(x => x.Id == productModel.Id)
                                                        .Select(x => new ProductEntity()
                                                        {
                                                            Id = x.Id,
                                                            Name = x.Name,
                                                            Price = x.Price,
                                                            OldPrice = x.Price,
                                                            Description = x.Description,
                                                            Summary = x.Summary,
                                                            Quantity = x.Quantity,
                                                            Weight = x.Weight,
                                                            Unit = x.Unit,
                                                            CategoryId = x.CategoryId,
                                                            CreatedDate = x.CreatedDate
                                                        }).First();
                entity.Name = productModel.Name;
                entity.Price = productModel.Price;
                entity.OldPrice = productModel.OldPrice;
                entity.Description = productModel.Description;
                entity.Summary = productModel.Summary;
                entity.Quantity = productModel.Quantity;
                entity.Weight = productModel.Weight;
                entity.Unit = productModel.Unit;
                entity.CategoryId = productModel.CategoryId;
                entity.UpdatedDate = DateTime.Now;
                _dbContext.ProductEntities.Update(entity);

                // tìm ava hiện tại
                var query = _dbContext.ProductImageEntities.Where(x => x.ProductId == productModel.Id)
                                                       .Where(x => x.IsAvatar == true)
                                                       .Select(x => new ProductImageEntity
                                                       {
                                                           Id = x.Id,
                                                           ProductId = x.ProductId,
                                                           FileId = x.FileId,
                                                           IsAvatar = x.IsAvatar,
                                                           CreatedDate = x.CreatedDate,
                                                           UpdatedDate = DateTime.Now
                                                       });
                // nếu có ava thì set nó về ảnh thường
                if (query.Any())
                {
                    var image = query.First();
                    image.IsAvatar = false;
                    _dbContext.ProductImageEntities.Update(image);
                }
            }

            // thêm ảnh đại diện
            _dbContext.ProductImageEntities.Add(new ProductImageEntity()
            {
                ProductId = productModel.Id,
                FileId = productModel.AvatarFileId,
                IsAvatar = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            _dbContext.SaveChanges();
            return Redirect("/Admin/Product/ListProduct");
        }

        public IActionResult Delete(int id)
        {
            var entity = _dbContext.ProductEntities.Find(id);
            entity.IsDeleted = true;
            _dbContext.ProductEntities.Update(entity);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Product/ListProduct");
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null)
            {
                return Json(new { status = "error" });
            }
            string folderUploads = Path.Combine(_environment.WebRootPath, "img\\product-image");
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var fileEntity = new FileManageEntity()
            {
                Name = file.Name,
                FilePath = "/img/product-image/" + fileName,
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

        public IActionResult AddImage(int id)
        {
            var query = (from x in _dbContext.ProductImageEntities
                         join y in _dbContext.ProductEntities on x.ProductId equals y.Id
                         join z in _dbContext.FileManageEntities on x.FileId equals z.Id
                         where x.IsDeleted == false
                         where y.Id == id
                         select new ProductImageModel
                         {
                             Id = x.Id,
                             ProductId = y.Id,
                             FileId = z.Id,
                             FilePath = z.FilePath,
                             IsAvatar = x.IsAvatar
                         }).ToList();
            var ava = (from x in _dbContext.ProductImageEntities
                              join y in _dbContext.ProductEntities on x.ProductId equals y.Id
                              join z in _dbContext.FileManageEntities on x.FileId equals z.Id
                              where x.IsDeleted == false
                              where y.Id == id
                              where x.IsAvatar == true
                              select new ProductImageModel
                              {
                                  Id = x.Id,
                                  ProductId = y.Id,
                                  FileId = z.Id,
                                  FilePath = z.FilePath,
                                  IsAvatar = true
                              });
            ViewBag.Avatar = ava == null ? new ProductImageModel()
                                        {
                                            Id = 0,
                                            ProductId = id,
                                            FileId = 0,
                                            FilePath = "/img/default.jpg",
                                        } : ava.First();
            return View(query);
        }

        [HttpPost]
        public IActionResult UpdateProductAvatar(ProductImageModel productImage)
        {
            // tìm ava trước
            var query = _dbContext.ProductImageEntities.Where(x => x.ProductId == productImage.ProductId)
                                                       .Where(x => x.IsAvatar == true)
                                                       .Select(x => new ProductImageEntity
                                                       {
                                                           Id = x.Id,
                                                           ProductId = x.ProductId,
                                                           FileId = x.FileId,
                                                           IsAvatar = x.IsAvatar,
                                                           CreatedDate = x.CreatedDate,
                                                           UpdatedDate = DateTime.Now
                                                       });
            // nếu có ava thì set nó về ảnh thường
            if (query.Any())
            {
                var image = query.First();
                image.IsAvatar = false;
                _dbContext.ProductImageEntities.Update(image);
            }
            // set prdImgModel trả về là ava
            var prd = _dbContext.ProductImageEntities.Where(p => p.Id == productImage.Id).Select(x => new ProductImageEntity
            {
                Id = x.Id,
                ProductId = x.ProductId,
                FileId = x.FileId,
                IsAvatar = true,
                CreatedDate = x.CreatedDate,
                UpdatedDate = DateTime.Now
            }).FirstOrDefault();
            _dbContext.ProductImageEntities.Update(prd);
            _dbContext.SaveChanges();
            return Redirect($"/Admin/Product/AddImage?id={productImage.ProductId}");
        }

        [HttpPost]
        public IActionResult UpdateProductImage(ProductImageModel productImage)
        {
            _dbContext.ProductImageEntities.Add(new ProductImageEntity()
            {
                ProductId = productImage.ProductId,
                FileId = productImage.FileId,
                IsAvatar = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }); 
            _dbContext.SaveChanges();
            return Redirect($"/Admin/Product/AddImage?id={productImage.ProductId}");
        }

    }
}
