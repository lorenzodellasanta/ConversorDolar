using ConversorDolar.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using Newtonsoft;
using System.Xml.Linq;
using System.Data.SqlTypes;

namespace ConversorDolar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProcessForm(int formData)
        {
            HttpClient httpClient = new();
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = true
            };
            var client = new HttpClient(handler);
            string apiUrl = $"https://openexchangerates.org/api?app_id=971c56ff8423492db257d766f4a28c8f";
            var toCurrency = "BRL";
            var fromCurrency = "USD";


            var response = await client.GetFromJsonAsync<ExchangeRateResult>(apiUrl);

            if (response.Rates.TryGetValue(toCurrency, out var toRate) &&
                response.Rates.TryGetValue(fromCurrency, out var fromRate))
            {
                // Convert amount
                var convertedAmount = formData * (toRate / fromRate);
                var retorno = convertedAmount;
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}