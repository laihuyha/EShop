using AspNetCoreHero.ToastNotification.Abstractions;
using EShop.Extension;
using EShop.Models;
using EShop.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly EcommerceVer2Context _context;
        public INotyfService _notyfService { get; } //Import services

        public CheckoutController(EcommerceVer2Context context, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _context = context;
        }

        #region Khởi tạo giỏ hàng
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang"); // Lấy từ trong Session
                if (gh == default(List<CartItem>)) //có thì thôi
                {
                    gh = new List<CartItem>(); // ko thì tạo
                    HttpContext.Session.Set<List<CartItem>>("GioHang", gh);
                }
                return gh;
            }
        }
        #endregion

        private int Exists(List<CartItem> carts, int id)
        {
            for (var i = 0; i < carts.Count; i++)
            {
                if (carts[i].product.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        [Route("Checkout.html", Name = "Checkout")]
        public IActionResult Index(string url = null)
        {
            List<CartItem> carts = GioHang;
            var CustomerId = HttpContext.Session.GetString("CustommerId");
            OrderViewModel model = new OrderViewModel();
            if(CustomerId != null)
            {
                var _customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustommerId == Convert.ToInt32(CustomerId));
                model.CustomerId = _customer.CustommerId;
                model.FullName = _customer.FullName;
                model.Email = _customer.Mail;
                model.Phone = _customer.Phone;
                model.Address = _customer.Address;
                model.Province = _customer.Province;
                model.District = _customer.District;
                model.Ward = _customer.Ward;
            }
            ViewBag.GioHang = carts;
            return View(model);
        }

        [HttpPost]
        [Route("Checkout.html", Name = "Checkout")]
        public IActionResult Index (OrderViewModel model)
        {
            return View();
        }
    }
}
