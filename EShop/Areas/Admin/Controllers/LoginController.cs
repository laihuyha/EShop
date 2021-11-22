using AspNetCoreHero.ToastNotification.Abstractions;
using EShop.Extension;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Login")]
    public class LoginController : Controller
    {
        private readonly EcommerceVer2Context _context;
        private SecurityManager securityManager = new SecurityManager();
        public INotyfService _notyfService { get; }
        public LoginController(EcommerceVer2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }


        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string username, string password)
        {
            var account = processLogin(username, password);
            if(account!= null)
            {
                securityManager.SignIn(this.HttpContext, account);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác";
                return View("Index");
            }
        }

        private Account processLogin(string username, string password)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.Username.Equals(username));
            if(account != null)
            {
                string pass = (password.Trim() + account.Randomkey.Trim()).PassToMD5();
                if(pass == account.Password)
                {
                    return account;
                }
            }
            return null;
        }

        [Route("Signout")]
        public IActionResult SignOut()
        {
            securityManager.SignOut(this.HttpContext);
            return RedirectToAction("Index", "Login", new { area = "Admin" });
        }
    }
}
