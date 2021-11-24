using AspNetCoreHero.ToastNotification.Abstractions;
using EShop.Extension;
using EShop.Models;
using EShop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ILogger<ShopCartController> _logger;
        private readonly EcommerceVer2Context _context;
        public INotyfService _notyfService { get; } //Import services

        public ShopCartController(EcommerceVer2Context context, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _context = context;
            _logger = logger;
        }
        [Route("CartItem.html",Name ="GioHang")]
        public IActionResult Index()
        {
            List<int> lstProductId = new List<int>();
            var lstGioHang = GioHang;
            return View(GioHang);
        }

        #region Khởi tạo giỏ hàng
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang"); // Lấy từ trong Session
                if(gh == default(List<CartItem>)) //có thì thôi
                {
                    gh = new List<CartItem>(); // ko thì tạo
                }
                return gh;
            }
        }
        #endregion

        #region Thao tác trên giỏ hàng
        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int productId, int? qty)
        {
            try
            {
                List<CartItem> carts = GioHang;

                //Thêm sản phẩm vào giỏ hàng
                CartItem item = GioHang.SingleOrDefault(x => x.product.ProductId == productId);
                if (item != null) // giỏ hàng có đồ
                {
                    if (qty.HasValue)
                    {
                        item.Qty = qty.Value; // số lượng = số lượng nhập vào
                    }
                    else
                    {
                        item.Qty++; // Số lượng tăng 1
                    }
                }
                else
                {
                    Product hh = _context.Products.SingleOrDefault(p => p.ProductId == productId);
                    item = new CartItem
                    {
                        Qty = qty.HasValue ? qty.Value : 1,
                        product = hh
                    };
                    carts.Add(item);
                }

                HttpContext.Session.Set<List<CartItem>>("GioHang", carts);
                return Json(new { succcess = true });
            }
            catch
            {
                return Json(new { succcess = false });
            }
        }

        [HttpPost]
        [Route("api/cart/remove")]
        public IActionResult Remove(int productId)
        {
            try
            {
                List<CartItem> carts = GioHang;
                CartItem item = carts.SingleOrDefault(a => a.product.ProductId == productId);
                if(item != null)
                {
                    carts.Remove(item);
                }
                HttpContext.Session.Set<List<CartItem>>("GioHang", carts);
                return Json(new { succcess = true });
            }
            catch (Exception)
            {
                return Json(new { succcess = false });
                throw;
            }
        }
        #endregion
    }
}
