using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConcreteShipping.Models;

namespace ConcreteShipping.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // ダッシュボードにリダイレクト
        return RedirectToAction("Index", "Dashboard");
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
