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
                .Include(n => n.Cate)
                .Where(n => n.IsActived && n.UnitInStock > 5)
                .OrderByDescending(n => n.DateCreated);
            ViewBag.ListNPD = lstNewProduct;

            var lstBestSeller = _context.Products
                .Include(n => n.Cate)
                .Include(n=>n.OrderDetails)
                .Where(n => n.IsActived && n.UnitInStock > 5 && n.IsBestsellers == true)
                .OrderByDescending(n => n.DateCreated);
            ViewBag.BestSeller = lstBestSeller;
            return View();
        }

        public ActionResult NPPartial()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
