using ConversorDolar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConversorDolar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient = new();
        private readonly string _apiKey = "5a0c73984ab847f68f6a5f3902631818";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {

            string apiUrl = $"https://open.er-api.com/v6/latest?app_id={_apiKey}";

            var response = await _httpClient.GetFromJsonAsync<ExchangeRateResult>(apiUrl);

            Conversor model = new()
            {
                Currencies = response.Rates.Select(a=> a.Key).ToList(),
                
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> ProcessForm(Conversor model)
        {

            string apiUrl = $"https://open.er-api.com/v6/latest?app_id={_apiKey}";
            var toCurrency = model.CurrencyDe;
            var fromCurrency = model.CurrencyPara;


            var response = await _httpClient.GetFromJsonAsync<ExchangeRateResult>(apiUrl);

            if (response.Rates.TryGetValue(toCurrency, out var toRate) &&
                response.Rates.TryGetValue(fromCurrency, out var fromRate))
            {
                // Convert amount
                var convertedAmount = Convert.ToDouble(model.FormValor) * (toRate / fromRate);
                TempData["Resultado"] = convertedAmount.ToString("0.00");
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