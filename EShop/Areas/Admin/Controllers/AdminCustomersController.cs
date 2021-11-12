using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCustomersController : Controller
    {
        private readonly EcommerceVer2Context _context;

        public AdminCustomersController(EcommerceVer2Context context)
        {
            _context = context;
        }

        // GET: Admin/AdminCustomers
        public IActionResult Index(int? page)
        {
            //Khai báo để phân trang
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5; /*Utilities.PAGE_SIZE;*/
            var lstCustomer = _context.Customers.AsNoTracking().Include(x => x.Location).OrderByDescending(x => x.CustommerId);
            PagedList<Customer> models = new PagedList<Customer>(lstCustomer, pageNo, pageSize);

            ViewBag.CurrentPage = pageNo;
            return View(models);
        }

        // GET: Admin/AdminCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.CustommerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Admin/AdminCustomers/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId");
            return View();
        }

        // POST: Admin/AdminCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustommerId,Password,FullName,BirthDay,Avatar,Address,Mail,Phone,LocationId,District,Ward,CreateDate,LastLogin,IsActived")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", customer.LocationId);
            return View(customer);
        }

        // GET: Admin/AdminCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", customer.LocationId);
            return View(customer);
        }

        // POST: Admin/AdminCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustommerId,Password,FullName,BirthDay,Avatar,Address,Mail,Phone,LocationId,District,Ward,CreateDate,LastLogin,IsActived")] Customer customer)
        {
            if (id != customer.CustommerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustommerId))
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", customer.LocationId);
            return View(customer);
        }

        // GET: Admin/AdminCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.CustommerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Admin/AdminCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustommerId == id);
        }
    }
}
