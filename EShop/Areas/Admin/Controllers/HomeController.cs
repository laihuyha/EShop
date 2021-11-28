using EShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Areas.Admin.Controllers
{
    
    
    //[Authorize(Roles = "Admin,Staff")]
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
            
            var lstCus = _context.Customers.Count();
            ViewBag.sumCus = lstCus;

            var lstOrder = _context.Orders.Count();
            ViewBag.sumOrder = lstOrder;

            var lstProduct = _context.Products.Count();
            ViewBag.sumProduct = lstProduct;

            
           
            ViewBag.sumOrder = lstOrder;
            return View();


        }

    }
}

