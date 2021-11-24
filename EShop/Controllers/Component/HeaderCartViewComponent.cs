using EShop.Extension;
using EShop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers.Component
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var carts = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(carts);
        }
    }
}
