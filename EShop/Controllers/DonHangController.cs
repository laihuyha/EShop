using AspNetCoreHero.ToastNotification.Abstractions;
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
    public class DonHangController : Controller
    {
        private readonly EcommerceVer2Context _context;
        public INotyfService _notyfService { get; } //Import services

        public DonHangController(EcommerceVer2Context context, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            try
            {
                var taikhoannID = HttpContext.Session.GetString("CustommerId");
                if (string.IsNullOrEmpty(taikhoannID)) return RedirectToAction("Login", "Accounts");
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustommerId == Convert.ToInt32(taikhoannID));
                if (khachhang == null) return NotFound();
                var donhang = _context.Orders
                    .Include(x => x.TransactionStatus)
                    .FirstOrDefault(m => m.OrderId == id && Convert.ToInt32(taikhoannID) == m.CustomerId);
                if(donhang == null)
                {
                    return NotFound();
                }
                var chitietdonhang = _context.OrderDetails
                    .Include(x => x.Product).AsNoTracking()
                    .Where(x => x.OrderId == id)
                    .OrderBy(x => x.OrderDetailId)
                    .ToList();
                XemDonHang donHang = new XemDonHang();
                donHang.DonHang = donhang;
                donHang.ChiTietDonHang = chitietdonhang;
                ViewBag.donHang = donHang;
                return View(donHang);
            }
            catch (Exception)
            {

                throw;
            }
            //return View();
        }
    }
}
