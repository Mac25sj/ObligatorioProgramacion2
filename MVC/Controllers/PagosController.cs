using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class PagosController : Controller
    {
        public IActionResult Pagos()
        {
            return View();
        }
    }
}
