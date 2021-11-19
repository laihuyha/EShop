using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EcommerceVer2Context _context;

        public ProductsController(EcommerceVer2Context context)
        {
            _context = context;
        }

        [Route("Laptop.html", Name = "Laptop")]
        public IActionResult Index(int? page)
        {
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 6;
            var lstLaptop = _context.Products
                .AsNoTracking()
                .Include(a => a.Cate)
                .Where(a=>a.IsActived && a.UnitInStock >0)
                .Include(a => a.Brand)
                .OrderByDescending(a => a.DateCreated);
            PagedList<Product> model = new PagedList<Product>(lstLaptop, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;
            return View(model);
        }

        public IActionResult Grid(string Alias, int? page)
        {
            return View();
        }

        [Route("/{Alias}-{id}.html", Name = "Details")]
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(a => a.Cate).Include(a => a.Brand).FirstOrDefault(x => x.ProductId == id);
            if(product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
    }
}
