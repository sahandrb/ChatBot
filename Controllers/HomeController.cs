using System.Diagnostics;
using System.Security.Claims;
using ChatBot.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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


        public IActionResult sendX(ChatBot.Models.ClientXModel xModel)
        {
            return View();
        }

        public IActionResult sendY(ChatBot.Models.ClientYModel yModel)
        {
            return View();
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientXView()
        {
            return View();
        }
        public IActionResult ClientYView()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ClientX(ChatBot.Models.ClientXModel xModel)
        {
            var Claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, xModel.Id.ToString()),
                
                };
            var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
            return RedirectToAction("sendX");
        }

        [HttpPost]
        public async Task<IActionResult> ClientY(ChatBot.Models.ClientYModel yModel)
        {
            var Claims = new List<Claim>
           {
               new Claim(ClaimTypes.NameIdentifier , yModel.Id.ToString()),
           };
            var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
            return View("sendY");

        }


        public IActionResult CheckClaims()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var name = User.Identity.Name;
                var idClaim = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                var messageClaim = User.Claims.FirstOrDefault(c => c.Type == "Message")?.Value;

                return Content($"Authenticated: true\nName: {name}\nId: {idClaim}\nMessage: {messageClaim}");
            }
            else
            {
                return Content("Authenticated: false");
            }
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
