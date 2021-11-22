using EShop.Models;
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

        public ShopCartController(ILogger<ShopCartController> logger, EcommerceVer2Context context)
        {
            _context = context;
            _logger = logger;
        }

        [Route("CartIndex.html",Name ="CartIndex")]
        public IActionResult Index()
        {
            return View();
        }

        //public List<Cart> GioHang
        //{
        //    get
        //    {
        //        var 
        //    }
        //}
    }
}
