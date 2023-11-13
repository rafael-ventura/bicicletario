using Microsoft.AspNetCore.Mvc;

namespace bicicletario.WebAPI.Controllers;

public class TotemController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
