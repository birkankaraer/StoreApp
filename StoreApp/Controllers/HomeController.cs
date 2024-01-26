using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Welcome";
        return View();
    }
        
}
