using AppManager.Areas.Admin.Models;
using AppAccountManager.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppAccountManager.Areas.Admin.Controllers
{        
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AccountController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountManagerModel model)
        {
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
                ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác";
                return Redirect("/admin/account/login");
            }    
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete("account");
            return Redirect("/admin/account/login");
        }
    }
}
