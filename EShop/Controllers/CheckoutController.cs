using AspNetCoreHero.ToastNotification.Abstractions;
using EShop.Extension;
using EShop.Helpper;
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
            if (CustomerId != null)
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
        public IActionResult Index(OrderViewModel model)
        {
            //lấy ra để xử lý
            List<CartItem> carts = GioHang;
            var _CustomerId = HttpContext.Session.GetString("CustommerId");
            OrderViewModel order = new OrderViewModel();
            if (_CustomerId != null)
            {
                var _customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustommerId == Convert.ToInt32(_CustomerId));
                order.CustomerId = _customer.CustommerId;
                order.FullName = _customer.FullName;
                order.Email = _customer.Mail;
                order.Phone = _customer.Phone;
                order.Note = model.Note;
                order.Address = _customer.Address;

                model.Province = _customer.Province;
                model.District = _customer.District;
                model.Ward = _customer.Ward;

                _context.Update(_customer);
                _context.SaveChanges();
            }
            try
            {
                //Khởi tạo đơn hàng
                Order donhang = new Order();
                donhang.CustomerId = order.CustomerId;
                donhang.Address = order.Address;
                donhang.Province = order.Province = model.Province;
                donhang.District = order.District = model.District;
                donhang.Ward = order.Ward = model.Ward;

                donhang.OrderDate = DateTime.Now;
                donhang.TransactionStatusId = 1;
                donhang.IsDeleted = false;
                donhang.IsPaid = false;
                donhang.Note = Utilities.StripHTML(order.Note);
                donhang.TotalMoney = Convert.ToDecimal(carts.Sum(x => x.TotalMoney));
                _context.Add(donhang);
                _context.SaveChanges();

                // tạo danh sách đơn hàng

                foreach (var item in carts)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderId = donhang.OrderId;
                    orderDetail.ProductId = item.product.ProductId;
                    orderDetail.Quantity = item.Qty;
                    orderDetail.Price = item.product.SalesPrice;
                    orderDetail.Total = (orderDetail.Price * orderDetail.Quantity);
                    orderDetail.CreateDate = DateTime.Now;
                    _context.Add(orderDetail);
                }
                _context.SaveChanges();
                HttpContext.Session.Remove("GioHang");
                _notyfService.Success("Đơn đặt thành công. Đang chờ xét duyệt");
                return RedirectToAction("Success", "Checkout");
            }
            catch (Exception)
            {

                throw;
            }
            ViewBag.GioHang = carts;
            return View(order);
        }

        [Route("Order-Success.html", Name = "Success")]
        public IActionResult Success()
        {
            try
            {
                var _CustomerId = HttpContext.Session.GetString("CustommerId");
                if (string.IsNullOrEmpty(_CustomerId))
                {
                    return RedirectToAction("Login", "Accounts", new { returnUrl = "/Order-Success.html" });
                }
                var _customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustommerId == Convert.ToInt32(_CustomerId));


                var _order = _context.Orders
                    .Where(x => x.CustomerId == Convert.ToInt32(_CustomerId))
                    .OrderByDescending(x => x.OrderDate).FirstOrDefault();

                OrderSuccessViewModel orderSuccess = new OrderSuccessViewModel();
                orderSuccess.FullName = _customer.FullName;
                orderSuccess.DonHangID = _order.OrderId;
                orderSuccess.NgayDat = _order.OrderDate;
                orderSuccess.Phone = _customer.Phone;
                orderSuccess.Address = _customer.Address;
                orderSuccess.TinhThanh = _order.Province;
                orderSuccess.QuanHuyen = _order.District;
                orderSuccess.PhuongXa = _order.Ward;
                return View(orderSuccess);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
