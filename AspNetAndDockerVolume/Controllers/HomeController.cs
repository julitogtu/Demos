using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAndDocker.Controllers
{
    public class HomeController : Controller
    {
        private readonly string basePath = $"{Directory.GetCurrentDirectory()}/Files";
        private readonly string pathFile = string.Empty;

        public HomeController()
        {
            if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);

            pathFile = $"{basePath}/log.txt";
        }
        
        public IActionResult Index(string msg) 
        {
            System.IO.File.AppendAllText(pathFile, $"{msg}\r");
            return Content(msg);
        }

        public IActionResult File()
        {
            return Content(System.IO.File.ReadAllText(pathFile));
        }
    }
}