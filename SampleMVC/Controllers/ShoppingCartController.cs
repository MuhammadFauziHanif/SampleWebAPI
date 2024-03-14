using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleMVC.ViewModels;

namespace SampleMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            return View(cart);
        }

        public IActionResult AddToCart(int productId, string productName, decimal price, int quantity)
        {
            var cart = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var existingItem = cart.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new ShoppingCartItem
                {
                    ProductId = productId,
                    Name = productName,
                    Price = price,
                    Quantity = quantity
                });
            }

            HttpContext.Session.Set("Cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart");
            var itemToRemove = cart.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
            }
            HttpContext.Session.Set("Cart", cart);
            return RedirectToAction("Index");
        }
    }
}
