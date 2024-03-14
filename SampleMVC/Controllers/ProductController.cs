using Microsoft.AspNetCore.Mvc;
using SampleMVC.ViewModels;

namespace SampleMVC.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99m },
            new Product { Id = 2, Name = "Product 2", Price = 15.49m },
            new Product { Id = 3, Name = "Product 3", Price = 5.99m }
            // Add more sample products as needed
        };

            return View(products);
        }
    }
}
