using CoffeeShopProductListLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeeShopProductListLab.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private CoffeeShopProductListDBContext context = new CoffeeShopProductListDBContext();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            List<Product> result = context.ProductDetails.ToList();
            return View(result);
        }

        public IActionResult ProductDetails(int postId)
        {
            Product p = context.ProductDetails.FirstOrDefault(p => p.ID == postId);
            return View(p);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
