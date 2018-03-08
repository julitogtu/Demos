using Microsoft.AspNetCore.Mvc;

namespace AspNetAndDocker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => Content("Running ASPNET Core in Docker");
    }
}