using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KampfsportVerwaltung.Models;
using KampfsportVerwaltung.Repositories;

namespace KampfsportVerwaltung.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        KaempferRepository repo = new KaempferRepository();
        List<Kaempfer> mykaempfers = repo.GetAllKaempfer();
        return View(mykaempfers);
    }

    public IActionResult Privacy()
    {
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}