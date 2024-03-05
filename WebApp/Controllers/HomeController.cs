using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("peter:peter123");
            string val = System.Convert.ToBase64String(plainTextBytes);
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + val);
            var data = await client.GetStringAsync("https://localhost:7088/api/User");
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
