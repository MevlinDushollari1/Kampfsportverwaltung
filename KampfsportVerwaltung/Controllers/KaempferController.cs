using KampfsportVerwaltung.Models;
using KampfsportVerwaltung.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KampfsportVerwaltung.Controllers;

public class KaempferController : Controller
{
    // GET
    public IActionResult Index()
    {
        KaempferRepository repo = new KaempferRepository();
        List<Kaempfer> mykaempfers = repo.GetAllKaempfer();
        return View(mykaempfers);
    }

    public IActionResult New()
    {
        return View();
        
    }
    [HttpPost]
    public IActionResult SaveKaempfer(Kaempfer kaempfer)
    {
        KaempferRepository repo = new KaempferRepository(); 
        repo.CreatKaempfer(kaempfer);
        return Redirect("/Kaempfer");
    }
}