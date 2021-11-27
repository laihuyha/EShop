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
    public class AdminOrdersController : Controller
    {
        private readonly EcommerceVer2Context _context;

        public AdminOrdersController(EcommerceVer2Context context)
        {
            _context = context;
        }

        public IActionResult Index(string searchStr, int? page)
        {
            var ecommerceVer2Context = from m in _context.Orders.Include(o => o.Customer).Include(o => o.TransactionStatus).OrderByDescending(x => x.OrderDate) select m;
            //Search
            ViewData["CurrentFilter"] = searchStr;
            if (!String.IsNullOrEmpty(searchStr))
            {
                ecommerceVer2Context = ecommerceVer2Context.Where(p => p.OrderId.ToString().Contains(searchStr) || p.CustomerId.ToString().Contains(searchStr));
            }

            //Paginate
            var pageNo = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            ViewBag.CurrentPage = pageNo;
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustommerId", "FullName");
            PagedList<Order> models = new PagedList<Order>(ecommerceVer2Context, pageNo, pageSize);
            return View(models);
        }


        // GET: Admin/AdminOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.TransactionStatus)
                .Where(o => o.IsDeleted == false)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            var chitietdohang = _context.OrderDetails
                .AsNoTracking()
                .Include(x => x.Product)
                .Where(x => x.OrderId == order.OrderId)
                .OrderBy(x => x.OrderDetailId)
                .ToList();
            ViewBag.ChiTiet = chitietdohang;
            return View(order);
        }

        // GET: Admin/AdminOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustommerId", "FullName");
            ViewData["TransactionStatusId"] = new SelectList(_context.TransactStatuses, "TransactionStatusId", "Descriptions");
            return View();
        }

        // POST: Admin/AdminOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderDate,ShipDate,TransactionStatusId,IsDeleted,IsPaid,PaymentDate,PaymentId,Note,TotalMoney,Address,Province,District,Ward")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustommerId", "FullName", order.CustomerId);
            ViewData["TransactionStatusId"] = new SelectList(_context.TransactStatuses, "TransactionStatusId", "Descriptions", order.TransactionStatusId);
            return View(order);
        }

        // GET: Admin/AdminOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustommerId", "FullName", order.CustomerId);
            ViewData["TransactionStatusId"] = new SelectList(_context.TransactStatuses, "TransactionStatusId", "Descriptions", order.TransactionStatusId);
            return View(order);
        }

        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderDate,ShipDate,TransactionStatusId,IsDeleted,IsPaid,PaymentDate,PaymentId,Note,TotalMoney,Address,Province,District,Ward")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var donhang = _context.Orders.AsNoTracking().Include(x => x.Customer).FirstOrDefault();
                    if (donhang != null)
                    {
                        donhang.IsPaid = order.IsPaid;
                        donhang.IsDeleted = order.IsDeleted;
                        donhang.TransactionStatusId = order.TransactionStatusId;
                        donhang.OrderDate = order.OrderDate;
                        //Khai báo Chitietdonhang có Id = donhang.Id
                        var orderdetail = _context.OrderDetails
                                .AsNoTracking()
                                .Where(x => x.OrderId == donhang.OrderId)
                                .Include(x => x.Product)
                                .ToList();
                        //Nhóm sản phẩm theo productID sau đó tính tổng số lượng
                        foreach (var item in orderdetail)
                        {
                            var product1 = _context.OrderDetails
                                .GroupBy(x => x.ProductId)
                                .Select(g => new
                                {
                                    Key = g.Key,
                                    Total = g.Sum(x=>x.Quantity)
                                })
                                .OrderByDescending(x => x.Total)
                                .ToList();
                            for(int i = 0; i < product1.Count; i++)
                            {
                                if(product1[i].Total >= 5)
                                {
                                    var product2 = _context.Products.Where(x => x.ProductId == product1[i].Key).FirstOrDefault();
                                    product2.IsBestsellers = true;
                                    _context.Update(product2);
                                }
                            }
                        }
                        // Nếu trạng thái đơn hàng đã xác nhận thông tin thah toán thì chuyển qua bước vận chuyển -> trừ vào số lượng hàng trong kho
                        if (donhang.TransactionStatusId == 3)
                        {
                            for (int i = 0; i < orderdetail.Count(); i++)
                            {
                                var product = _context.Products
                                    .Where(x => x.ProductId == orderdetail[i].ProductId)
                                    .FirstOrDefault();
                                product.UnitInStock = (product.UnitInStock - orderdetail[i].Quantity);
                                _context.Update(product);
                            }
                        }
                        // Nếu đơn hàng đã giao thì chuyển trạng thái Delete = true;
                        if (donhang.TransactionStatusId == 5)
                        {
                            donhang.IsDeleted = true;
                        }
                    }
                    _context.Update(donhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustommerId", "FullName", order.CustomerId);
            ViewData["TransactionStatusId"] = new SelectList(_context.TransactStatuses, "TransactionStatusId", "Descriptions", order.TransactionStatusId);
            return View(order);
        }

        // GET: Admin/AdminOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.TransactionStatus)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/AdminOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
