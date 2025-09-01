using System.Diagnostics;
using System.Security.Claims;
using ChatBot.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public object ClaimType { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientX(ChatBot.Models.ClientXModel xModel)
        {

            return View();
        }

        public IActionResult ClientY(ChatBot.Models.ClientYModel yModel)
        {
           var Claims = new List<Claim>
           {
               new Claim(ClaimTypes.NameIdentifier , yModel.Name),
               new Claim("Id" , yModel.Id.ToString()),
               new Claim("Message" , yModel.Message)
           }
            return View();
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
}
