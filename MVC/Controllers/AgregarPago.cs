using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AgregarPago : Controller
    {
        public IActionResult NuevoPago()
        {
            return View();
        }
    }
}
