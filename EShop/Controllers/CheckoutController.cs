using AspNetCoreHero.ToastNotification.Abstractions;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly EcommerceVer2Context _context;
        public INotyfService _notyfService { get; } //Import services

        public CheckoutController(EcommerceVer2Context context, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
