using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop.Models;
using PagedList.Core;
using System.Globalization;
using System.IO;
using EShop.Helpper;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly EcommerceVer2Context _context;
        public static string image;
        public INotyfService _notyfService { get; }

        public AdminProductsController(EcommerceVer2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        string app_Id = "1117157035770463";
        string secret_Key = "8a5ac077fcdf135c837aefa9b9c65dfa";
        string pageId = "109789021642472";
        string _app_Access_token = "1117157035770463|PGXmgWAd0VyqaU2PQhw_SKJPctc";
        string _page_access_token = "EAAP4DGRGgl8BAJmQ461xddH7jUHzCxaISTV43zovg8j41ZAfovkq6a9FbGItPXQVXZBspEOPMiVVbi9reT6GiGu9IuIRoUYbvtqdU4uUdyOmZAzNpSpKS8uKQ73wA1WAWgVB8FdY0KCZATm56aDE2jaUEQjYchqagLshJts4AynE5ZB6SMCMzS06MjkAH7rvgmXaefVhsNwcN46Eivw8A";
        string short_term_token = "EAAP4DGRGgl8BAEvK6mManpV6CZBT6qkKhi87ZArLabGqVWQqkOTceBTWZABYenVgxcIqnroJIb2XHa1ck7z0aHcD5LJgc7MnhZAZClWVZAtxCdZB0YigPKHHG6mqJ28ZArdnc3tmDncBx3SkwNIazKv3qICH8DrHt8tZBrFtYCJIeBkqvv0UwxsIumoCF3a9Wm16QiZCG9TlA8lrx6PC0VoErfTce70ZBHlaMz7ckGNj2yAj4jlF5zc3he9lOZCx0HZBdiH4ZD";
        string long_term_access_token = "EAAP4DGRGgl8BAEieGIVewKqfQLZCKaaRLRtblG1DPV6si07fSpchcKXWbIe8ZBpN4azXSLbJ6Gz5i7edemEWZCgBoBjJ8TO8iFVprTyhP4aFsQf4VE9ueDWUS6DpMzmXA28BGzBZAfqDEuVvSvNfGqhUenEGLu4HOZCNDDOPIkzCxBce47tlR";
        string real_page_token = "EAAP4DGRGgl8BALKRCsuajaOC1Ye0kMGEVetZB1KBN0DlTBNf8ncIZBtQatmb1JT3uGOochJ376HOcLYMgvp5gtifXUkTZBB2YG6XkFa46wvRQPIb1mSzpall1zomlUg4y8CufK21NgRBncxaB3FARbfUw6xStIEdepKu53WXyWQYr7QlRSgGDzFRu257GB6EAV6PucZATZCNYqXCPyX18";

        // GET: Admin/AdminProducts
        public IActionResult Index(string sortOrder, string currentFilter, string searchStr, int? page)
        {
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName");
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            var _product = from m in _context.Products.Include(p => p.Brand).Include(p => p.Cate) select m;
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
                .Include(p => p.Brand)
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName");
            return View();
        }

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ShortDesc,Descriptions,CateId,Price,Discount,ThumbImg,Video,DateCreated,DateModified,IsBestsellers,Homeflag,IsActived,Tag,Title,Alias,UnitInStock,BrandId,SalesPrice")] Product product, Microsoft.AspNetCore.Http.IFormFile fThumbImg)
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
                product.SalesPrice = product.Price.Value - (product.Price.Value * (product.Discount.Value) / 100);
                if (product.Discount == null)
                {
                    product.Discount = 0;
                }
                _context.Add(product);
                _notyfService.Success("Thêm thành công!");
                await _context.SaveChangesAsync();

                //#region // Post with photo
                Facebook facebook = new Facebook(real_page_token, pageId);
                //string result = facebook.PublishToFacebook("some text", "https://www.google.com/aclk?sa=l&ai=DChcSEwj-4eGRlZj2AhVhn8IKHWqVASQYABALGgJ0bQ&sig=AOD64_1G9M4Rah6BsMWpVTaOvMuWPVo6LQ&adurl&ctype=5&ved=2ahUKEwjppNORlZj2AhVMAqYKHbtLBb4Qwg96BAgBEGU");
                //Console.WriteLine(result);
                //#endregion
                string text_to_send = $"Tên sản phẩm : "+$"{product.ProductName}" + "\n" + $"Giá chỉ còn : " + $"{product.SalesPrice}";
                //2) if you want just to publish a simple text post
                var rezText = Task.Run(async () =>
                {
                    using (var http = new HttpClient())
                    {
                        return await facebook.PublishSimplePost(text_to_send);
                    }
                });
                var rezTextJson = JObject.Parse(rezText.Result.Item2);
                if (rezText.Result.Item1 != 200)
                {
                    try // return error from JSON
                    {
                        Console.WriteLine($"Error posting to Facebook. {rezTextJson["error"]["message"].Value<string>()}");
                        //return;
                    }
                    catch (Exception ex) // return unknown error
                    {
                        // log exception somewhere
                        Console.WriteLine($"Unknown error posting to Facebook. {ex.Message}");
                        //return;
                    }
                }
                Console.WriteLine(rezTextJson);

                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.BrandId);
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.BrandId);
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName", product.CateId);
            return View(product);
        }

        // POST: Admin/AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ShortDesc,Descriptions,CateId,Price,Discount,ThumbImg,Video,DateCreated,DateModified,IsBestsellers,Homeflag,IsActived,Tag,Title,Alias,UnitInStock,BrandId,SalesPrice")] Product product, Microsoft.AspNetCore.Http.IFormFile fThumbImg)
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
                    product.SalesPrice = product.Price.Value - (product.Price.Value * (product.Discount.Value) / 100);
                    if (product.Discount == null)
                    {
                        product.Discount = 0;
                    }
                    _context.Update(product);
                    _notyfService.Success("Sửa thành công!");
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName", product.BrandId);
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName", product.CateId);
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        // GET: Admin/AdminProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Cate)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/AdminProducts/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }


        public IActionResult SPGanHet(string sortOrder, string currentFilter, string searchStr, int? page)
        {
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName");
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            var _product = from m in _context.Products.Include(p => p.Brand).Include(p => p.Cate).Where(p => p.UnitInStock < 5) select m;
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

        public IActionResult BestSeller(string sortOrder, string currentFilter, string searchStr, int? page)
        {
            ViewData["CateId"] = new SelectList(_context.Categories, "CateId", "CategoryName");
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            var _product = from m in _context.Products.Include(p => p.Brand).Include(p => p.Cate).Where(x => x.IsBestsellers == true) select m;
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
    }
}
