using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EcommerceVer2Context _context;

        public HomeController(ILogger<HomeController> logger, EcommerceVer2Context context)
        {
            _context = context;
            _logger = logger;
        }

        public ActionResult Index()
        {
            var lstNewProduct = _context.Products
                .Include(n=>n.Cate)
                .Where(n => n.IsActived && n.UnitInStock>5)
                .OrderByDescending(n => n.DateCreated);
            ViewBag.ListNPD = lstNewProduct;
            return View();
        }

        [Route("LatopShop.html", Name = "Laptop Store")]
        public IActionResult Laptops(int? page)
        {
            var lstLatop = from m in _context.Products.Include(n => n.CateId == 1 && n.IsActived) select m;
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            PagedList<Product> models = new PagedList<Product>(lstLatop, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;

            return View(models);
        }
        [Route("Dien-thoai.html", Name = "Smart Phone Store")]
        public IActionResult SmartPhone()
        {
            return View();
        }
        [Route("Phu-kien.html", Name = "Accessories Store")]
        public IActionResult Accessories()
        {
            return View();
        }
        [Route("Thuong-hieu.html", Name = "Brand Store")]
        public IActionResult Brand()
        {
            return View();
        }
        [Route("Ha-gia.html", Name = "Sales Store")]
        public IActionResult Sales()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
