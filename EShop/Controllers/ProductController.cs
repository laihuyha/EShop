using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Linq;

namespace EShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly EcommerceVer2Context _context;

        public ProductController(EcommerceVer2Context context)
        {
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            try
            {
                //Paginate
                var pageNo = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 10;
                var _lstProduct = from m in _context.Products.AsNoTracking().OrderByDescending(x => x.ProductId) select m;
                PagedList<Product> models = new PagedList<Product>(_lstProduct, pageNo, pageSize);
                ViewBag.CurrentPage = pageNo;
                return View();
            }
            catch (System.Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }

        [Route("/{Alias}-{id}.html", Name ="ProductDetails")]
        public IActionResult ProductDetails(int id)
        {
            try
            {
                var product = _context.Products.Include(x => x.Cate).FirstOrDefaultAsync(x => x.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (System.Exception)
            {
                return RedirectToAction("Index", "Home");
                throw;
            }
        }
    }
}
