using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShop.Models;
using PagedList.Core;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoriesController : Controller
    {
        private readonly EcommerceVer2Context _context;

        public AdminCategoriesController(EcommerceVer2Context context)
        {
            _context = context;
        }

        // GET: Admin/AdminCategories
        public IActionResult Index(string sortOrder, string currentFilter, string searchStr, int? page)
        {
            var _category = from m in _context.Categories select m;
            //Sort
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["TitleSortParm"] = sortOrder == "Title" ? "title_desc" : "Title";
            ViewData["CurrentSort"] = sortOrder;
            switch (sortOrder)
            {
                case "id_desc":
                    _category = _category.OrderByDescending(p => p.CateId);
                    break;
                case "Name":
                    _category = _category.OrderBy(p => p.CategoryName);
                    break;
                case "name_desc":
                    _category = _category.OrderByDescending(p => p.CategoryName);
                    break;
                case "title_desc":
                    _category = _category.OrderByDescending(p => p.Title);
                    break;
                case "Title":
                    _category = _category.OrderBy(p => p.Title);
                    break;
                case "Disable":
                    _category = _category.OrderBy(p => p.IsPublished);
                    break;
                case "Publish":
                    _category = _category.OrderByDescending(p => p.IsPublished);
                    break;
                default:
                    _category = _category.OrderBy(p => p.CateId);
                    break;
            }

            //Search
            ViewData["CurrentFilter"] = searchStr;
            if (!String.IsNullOrEmpty(searchStr))
            {
                _category = _category.Where(p => p.CateId.ToString().Contains(searchStr) || p.CategoryName.Contains(searchStr) || p.Descriptions.Contains(searchStr)|| p.Title.Contains(searchStr));
            }

            //Paginate
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            ViewBag.CurrentPage = pageNo;
            PagedList<Category> models = new PagedList<Category>(_category, pageNo, pageSize);
            return View(models);
        }

        // GET: Admin/AdminCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/AdminCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CateId,CategoryName,Descriptions,ParentId,Levels,Ordering,IsPublished,ThumbImg,Title,Alias,Cover")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/AdminCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CateId,CategoryName,Descriptions,ParentId,Levels,Ordering,IsPublished,ThumbImg,Title,Alias,Cover")] Category category)
        {
            if (id != category.CateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CateId))
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
            return View(category);
        }

        // GET: Admin/AdminCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CateId == id);
        }
    }
}
