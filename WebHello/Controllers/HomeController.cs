using Microsoft.AspNetCore.Mvc;
using WebHello.Models;

namespace WebHello.Controllers
{
    public class HomeController(IWebHostEnvironment env) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Greet(VisitorModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return RedirectToAction("Index");
            }

            string greeting = GetGreeting();
            string message = $"{greeting}, {model.Name}!";

            string logPath = Path.Combine(env.ContentRootPath, "App_Data", "visitorlog.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(logPath));

            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {model.Name}";
            System.IO.File.AppendAllText(logPath, logEntry + Environment.NewLine);

            ViewBag.GreetingMessage = message;
            return View();
        }

        private string GetGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 0 && hour < 10)
                return "Jó reggelt";
            else if (hour >= 10 && hour < 17)
                return "Jó napot";
            else
                return "Jó estét";
        }
    }
}