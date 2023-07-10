using Microsoft.AspNetCore.Mvc;

namespace BiletiApp.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult AddToCart()
        {
            return View();
        }
    }
}
