using AppManager.Areas.Admin.Models;
using AppAccountManager.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppManager.Models;
using AppManager.Entities;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AppAccountManager.Areas.Admin.Controllers
{        
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _dbContext;
        private IWebHostEnvironment _environment;

        public AccountController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public string GetAccount()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var account = claims.FindFirst(ClaimTypes.NameIdentifier).Value;
            return account;
        }

        public IActionResult UserProfile(string account)
        {
            var acc = string.IsNullOrEmpty(account) ? GetAccount() : account;
            var user = (from a in _dbContext.UserEntities
                       join b in _dbContext.AccountImageEntities on a.Account equals b.Account
                       join c in _dbContext.FileManageEntities on b.FileId equals c.Id
                       join d in _dbContext.AccountManagerEntities on a.Account equals d.Account
                       where b.IsDeleted == false && b.IsAvatar == true
                       where a.Account == acc
                       select new UserModel
                       {
                           Account = acc,
                           FirstName = a.FirstName,
                           LastName = a.LastName,
                           Phone = a.Phone,
                           Email = a.Email,
                           AvatarId = c.Id,
                           AvatarPath = c.FilePath,
                           Role = d.Role,
                       }).First();
            return View(user);
        }

        [HttpGet]
        public IActionResult UpdateAvatar(string account, int oldId, int newId)
        {
            var oldImage = _dbContext.AccountImageEntities.First(x => x.FileId == oldId);
            oldImage.IsAvatar = false;
            _dbContext.AccountImageEntities.Update(oldImage);
            var newImage = new AccountImageEntity()
            {
                Account = account,
                FileId = newId,
                IsAvatar = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = account,
                UpdatedBy = account,
            };
            _dbContext.AccountImageEntities.Add(newImage);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Account/UserProfile");
        }

        [HttpPost]
        public IActionResult UserProfile(UserModel model)
        {
            var account = _dbContext.AccountManagerEntities.Where(x => x.Account == model.Account)
                                                            .Select(x => new AccountManagerEntity()
                                                            {
                                                                Account = x.Account,
                                                                Password = x.Password,
                                                                Role = x.Role,
                                                                CreatedDate = x.CreatedDate,
                                                                UpdatedDate = x.UpdatedDate,
                                                            }).First();
            account.Role = model.Role;
            account.UpdatedDate = DateTime.Now;
            account.UpdatedBy = model.Account;
            _dbContext.AccountManagerEntities.Update(account);
            var entity = _dbContext.UserEntities.Where(x => x.Account == model.Account)
                                                .Select(x => new UserEntity()
                                                {
                                                    CreatedDate = x.CreatedDate,
                                                }).First();
            entity.Account = model.Account;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Phone = model.Phone;
            entity.Email = model.Email;
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = GetAccount();
            
            _dbContext.UserEntities.Update(entity);
            _dbContext.SaveChanges();
            return UserProfile(model.Account);
        }


        public IActionResult Login(string ReturnUrl)
        {
            var cl = HttpContext.User.Identity as ClaimsIdentity;
            if (cl.Claims.Any())
            {
                var role = cl.Claims.Where(c => c.Type == ClaimTypes.Role)
                                    .Select(c => c.Value).SingleOrDefault();
                if (role == "customer")
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    var returnUrl = string.IsNullOrEmpty(ReturnUrl) ? "/admin/home/index" : ReturnUrl;
                    return Redirect(returnUrl);
                }
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountManagerModel model)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                TempData["Error"] = error.FirstOrDefault();
                return Redirect("/admin/account/login");
            }
            var query = _dbContext.AccountManagerEntities.Where(a => a.Account == model.Account && a.Password == model.Password)
                                                  .Select(a => new AccountManagerModel()
                                                    {
                                                        Account = a.Account,
                                                        Password = a.Password,
                                                        Role = a.Role
                                                    }).ToList();
            if (query.Any())
            {
                var account = query.FirstOrDefault();
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Account)
                };
                claims.Add(new Claim(ClaimTypes.Role, account.Role));
                var claimIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIndentity));
                HttpContext.Response.Cookies.Append("account", account.Account);
                
                if (account.Role == "customer")
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    var returnUrl = string.IsNullOrEmpty(model.ReturnUrl) ? "/admin/home/index" : model.ReturnUrl;
                    return Redirect(returnUrl);
                }
            }
            else
            {
                TempData["Error"] = "Tài khoản hoặc mật khẩu không chính xác!";
                return Redirect("/admin/account/login");
            }    
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                TempData["Error"] = error.FirstOrDefault();
                return Redirect("/admin/account/signup");
            }
            var query = _dbContext.UserEntities.Where(x => x.Account == user.Account || x.Email == user.Email)
                                               .Select(x => new UserEntity() { });
            if (query.Any())
            {
                TempData["Error"] = "Đã có tài khoản này!";
                return Redirect("/admin/account/signup");
            }

            _dbContext.AccountManagerEntities.Add(new AccountManagerEntity()
            {
                Account = user.Account,
                Password = user.Password,
                Role = "customer",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            _dbContext.SaveChanges();
            _dbContext.UserEntities.Add(new UserEntity()
            {
                Account = user.Account,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            _dbContext.SaveChanges();
            _dbContext.AccountImageEntities.Add(new AccountImageEntity()
            {
                Account = user.Account,
                FileId = user.AvatarId,
                IsAvatar = true,
                CreatedDate = DateTime.Now,
                CreatedBy = user.Account,
                UpdatedDate = DateTime.Now,
                UpdatedBy = user.Account,
            });
            _dbContext.SaveChanges();
            return Redirect("/admin/account/login");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete("account");
            return Redirect("/admin/account/login");
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null)
            {
                return Json(new { status = "error" });
            }
            string folderUploads = Path.Combine(_environment.WebRootPath, "img\\user-avatar");
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var fileEntity = new FileManageEntity()
            {
                Name = file.Name,
                FilePath = "/img/user-avatar/" + fileName,
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
                FilePath = fileEntity.FilePath
            };
            return Json(model);
        }

    }
}
