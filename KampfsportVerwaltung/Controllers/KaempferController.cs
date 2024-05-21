using Microsoft.AspNetCore.Mvc;

namespace KampfsportVerwaltung.Controllers;

public class KaempferController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}