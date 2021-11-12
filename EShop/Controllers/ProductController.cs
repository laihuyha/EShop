using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly EcommerceVer2Context _context;

        public ProductController(EcommerceVer2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _context.Products.Include(x => x.Cate).FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
