using EShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    [Area("Admin")]
    [Route("Admin/Dashboard")]
    public class HomeController : Controller
    {
        private readonly EcommerceVer2Context _context;
        public HomeController(EcommerceVer2Context context)
        {
            _context = context;
        }

        [Route("Index")]
        public ActionResult Index()
        {
            //Thống kê tổng số khách hàng
            var lstCus = _context.Customers.Count();
            ViewBag.sumCus = lstCus;

            //Thống kê tổng số đơn hàng
            var lstOrder = _context.Orders.Count();
            ViewBag.sumOrder = lstOrder;

            //Thống kê tổng số sản phẩm
            var lstProduct = _context.Products.Count();
            ViewBag.sumProduct = lstProduct;

            //Thống kê những đơn hàng chưa duyệt
            var lstUnapprovedOrder = _context.Orders.Where(x => x.TransactionStatusId == 1).Count();
            ViewBag.lstUnapprovedOrder = lstUnapprovedOrder;

            //Thống kê doanh thu tháng này
            var mRevenue = _context.Orders.Where(x => x.TransactionStatusId == 3 && x.OrderDate.Month == DateTime.Now.Month).Sum(x => x.TotalMoney).Value.ToString("#,##0");
            ViewBag.mRevenue = mRevenue;

            //Thống kê doanh thu năm này
            var yRevenue = _context.Orders.Where(x => x.TransactionStatusId == 3 && x.OrderDate.Year == DateTime.Now.Year).Sum(x => x.TotalMoney).Value.ToString("#,##0");
            ViewBag.yRevenue = yRevenue;

            //Thống kê sản phẩm bán chạy
            var bSellProduct = _context.Products.Where(x => x.IsBestsellers == true).Count();
            ViewBag.bSellProduct = bSellProduct;
            //Thống kê Lợi nhuận
            return View();
        }
    }
}

