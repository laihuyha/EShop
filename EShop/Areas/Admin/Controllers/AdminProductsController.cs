using AspNetCoreHero.ToastNotification.Abstractions;
using EShop.Helpper;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly EcommerceVer2Context _context;
        public INotyfService _notyfService { get; }
        public static string image;

        public AdminProductsController(EcommerceVer2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminProducts
        public IActionResult Index(string sortOrder, string currentFilter, string searchStr, int? page)
        {
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName");

            var _product = from p in _context.Products.Include(p => p.Cate) select p;

            //Sort
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["UnitSortParm"] = sortOrder == "Unit" ? "unit_desc" : "Unit";
            ViewData["CurrentSort"] = sortOrder;
            switch (sortOrder)
            {
                case "id_desc":
                    _product = _product.OrderByDescending(p => p.ProductId);
                    break;
                case "Date":
                    _product = _product.OrderBy(p => p.DateCreated);
                    break;
                case "date_desc":
                    _product = _product.OrderByDescending(p => p.DateCreated);
                    break;
                case "unit_desc":
                    _product = _product.OrderByDescending(p => p.UnitInStock);
                    break;
                case "Unit":
                    _product = _product.OrderBy(p => p.UnitInStock);
                    break;
                default:
                    _product = _product.OrderBy(p => p.ProductId);
                    break;
            }

            //Search
            ViewData["CurrentFilter"] = searchStr;
            if (!String.IsNullOrEmpty(searchStr))
            {
                _product = _product.Where(p => p.ProductName.Contains(searchStr) || p.ProductId.ToString().Contains(searchStr));
            }

            //Paginate
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            PagedList<Product> models = new PagedList<Product>(_product, pageNo, pageSize);
            ViewBag.CurrentPage = pageNo;

            return View(models);
        }

        // GET: Admin/AdminProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Cate)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/AdminProducts/Create
        public IActionResult Create()
        {
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName");
            return View();
        }

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ShortDesc,Descriptions,CateId,Price,Discount,ThumbImg,Video,DateCreated,DateModified,IsBestsellers,Homeflag,IsActived,Tag,Title,Alias,UnitInStock")] Product product, Microsoft.AspNetCore.Http.IFormFile fThumbImg)
        {
            if (ModelState.IsValid)
            {
                product.ProductName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(product.ProductName);
                if (fThumbImg != null)
                {
                    string extennsion = Path.GetExtension(fThumbImg.FileName);
                    image = Utilities.ToUrlFriendly(product.ProductName) + extennsion;
                    product.ThumbImg = await Utilities.UploadFile(fThumbImg, @"products", image.ToLower());
                }
                if (string.IsNullOrEmpty(product.ThumbImg)) product.ThumbImg = "thumb-6.jpg";
                product.Alias = Utilities.ToUrlFriendly(product.ProductName);
                product.DateCreated = DateTime.Now;
                product.DateModified = DateTime.Now;
                if (product.Discount == null)
                {
                    product.Discount = 0;
                }
                _context.Add(product);
                _notyfService.Success("Thêm thành công!");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName", product.CateId);
            return View(product);
        }

        // GET: Admin/AdminProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName", product.CateId);
            return View(product);
        }

        // POST: Admin/AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ShortDesc,Descriptions,CateId,Price,Discount,ThumbImg,Video,DateCreated,DateModified,IsBestsellers,Homeflag,IsActived,Tag,Title,Alias,UnitInStock")] Product product, Microsoft.AspNetCore.Http.IFormFile fThumbImg)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.ProductName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(product.ProductName);
                    if (fThumbImg != null)
                    {
                        string extennsion = Path.GetExtension(fThumbImg.FileName);
                        image = Utilities.ToUrlFriendly(product.ProductName) + extennsion;
                        product.ThumbImg = await Utilities.UploadFile(fThumbImg, @"products", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(product.ThumbImg)) product.ThumbImg = "thumb-6.jpg";
                    product.Alias = Utilities.ToUrlFriendly(product.ProductName);
                    product.DateModified = DateTime.Now;
                    _context.Update(product);
                    _notyfService.Success("Sửa thành công!");
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        _notyfService.Error("Lỗi!!!!!!!!!!!!!!!");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName", product.CateId);
            return View(product);
        }

        // GET: Admin/AdminProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Cate)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            string imageName = image.ToLower();
            //string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products\\" + imageName);
            //if (System.IO.File.Exists(fullPath))
            //{
            //    System.IO.File.Delete(fullPath);
            //}
            //Utilities.DeleteImage(@"products",imageName);
            Utilities.DeleteImage(@"products", imageName);
            _context.Products.Remove(product);
            _notyfService.Success("Xóa thành công!");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }


    }
}
