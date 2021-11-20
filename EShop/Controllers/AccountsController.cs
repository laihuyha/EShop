using AspNetCoreHero.ToastNotification.Abstractions;
using EShop.Extension;
using EShop.Helpper;
using EShop.Models;
using EShop.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    public class AccountsController : Controller
    {
        private readonly EcommerceVer2Context _context;
        public INotyfService _notyfService { get; }
        public static string image;

        public AccountsController(EcommerceVer2Context context, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _context = context;
        }

        [Route("Index.html", Name = "TrangChu")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidatePhone(string Phone)
        {
            try
            {
                var _Customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Phone.ToLower() == Phone);
                if (_Customer != null)
                {
                    return Json(data: "Số : " + Phone + "này đã được sử dụng");
                }
                return Json(data: true);
            }
            catch
            {

                return Json(data: true);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateEmail(string Email)
        {
            try
            {
                var _Customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Mail.ToLower() == Email);
                if (_Customer != null)
                {
                    return Json(data: "Email : " + Email + "này đã được sử dụng");
                }
                return Json(data: true);
            }
            catch
            {

                return Json(data: true);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateUserName(string User)
        {
            try
            {
                var _Customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Username.ToLower() == User);
                if (_Customer != null)
                {
                    return Json(data: "Tên tài khoản : " + User + "này đã được sử dụng");
                }
                return Json(data: true);
            }
            catch
            {

                return Json(data: true);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("Register.html", Name = "DangKy")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register.html", Name = "DangKy")]
        public async Task<IActionResult> Register(RegisterViewModel Taikhoan, Microsoft.AspNetCore.Http.IFormFile fAvatar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string RandomKey = Utilities.GetRandomKey();
                    if (fAvatar != null)
                    {
                        string extennsion = Path.GetExtension(fAvatar.FileName);
                        image = Utilities.ToUrlFriendly(Taikhoan.FullName) + extennsion;
                        Taikhoan.Avatar = await Utilities.UploadFile(fAvatar, @"User", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(Taikhoan.Avatar)) Taikhoan.Avatar = "avatar.png";
                    Customer Acc = new Customer
                    {
                        FullName = Taikhoan.FullName,
                        Username = Taikhoan.Username,
                        BirthDay = Taikhoan.BirthDay,
                        Phone = Taikhoan.Phone.Trim().ToLower(),
                        Mail = Taikhoan.Mail.Trim().ToLower(),
                        Address = Taikhoan.Address,
                        Province = Taikhoan.Province,
                        District = Taikhoan.District,
                        Ward = Taikhoan.Ward,
                        Password = (Taikhoan.Password + RandomKey.Trim()).PassToMD5(),
                        IsActived = true,
                        Randomkey = RandomKey,
                        CreateDate = DateTime.Now,
                        Avatar = Taikhoan.Avatar
                    };
                    try
                    {
                        _context.Add(Acc);
                        _notyfService.Success("Thêm thành công!");
                        await _context.SaveChangesAsync();

                        //Lưu luôn Session đỡ phải Login lại
                        //Lưu Session cho CustomerId
                        HttpContext.Session.SetString("CustommerId", Acc.CustommerId.ToString());
                        var AccID = HttpContext.Session.GetString("CustommerId");
                        //Identity
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, Acc.FullName),
                            new Claim("CustommerId", Acc.CustommerId.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        return RedirectToAction("Register", "Accounts");
                    }
                    catch
                    {
                        return RedirectToAction("Register", "Accounts");
                    }
                }
                else
                {
                    return View(Taikhoan);
                }
            }
            catch
            {

                return View(Taikhoan);
            }
        }

        [AllowAnonymous]
        [Route("Login.html", Name = "DangNhap")]
        public IActionResult Login(string returnUrl = null)
        {
            var AccID = HttpContext.Session.GetString("CustommerId");
            if(AccID != null)
            {
                return RedirectToAction("Index", "Accounts");
            }
            ViewBag.ReturnURL = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login.html", Name = "DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var CTM = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Username.Trim() == model.UserName);
                    if(CTM == null)
                    {
                        return RedirectToAction("Register", "Accounts");
                    }
                    string pass = (model.Password + CTM.Randomkey.Trim()).PassToMD5();

                    //Kiểm tra pass có giống vs Password ko
                    if(CTM.Password != pass)
                    {
                        _notyfService.Error("Thông tin đăng nhập không chính xác");
                        return View(CTM);
                    }

                    //Kiểm tra Acc có bị Disable không
                    if(CTM.IsActived == false)
                    {
                        return RedirectToAction("Notice", "Accounts");
                    }

                    //Lưu luôn Session đỡ phải Login lại
                    //Lưu Session cho CustomerId
                    HttpContext.Session.SetString("CustommerId", CTM.CustommerId.ToString());
                    var AccID = HttpContext.Session.GetString("CustommerId");
                    //Identity
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, CTM.FullName),
                            new Claim("CustommerId", CTM.CustommerId.ToString())
                        };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notyfService.Custom("Đăng nhập thành công!",5, "#EAB14E", "far fa-hand-peace");
                    return RedirectToAction("Index", "Accounts");
                }
                return RedirectToAction("Register", "Accounts");
            }
            catch
            {
                return RedirectToAction("Index", "Accounts");
            }
            return View(model);
        }
    }
}
