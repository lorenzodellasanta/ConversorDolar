using ConversorDolar.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using Newtonsoft;

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
        public IActionResult ProcessForm(string formData)
        {
            string apikey = "287e902dd3ab447fa1780dc170f7902e";
            string baseCurrency = "BRL";//Moeda base (Reais)
            string targetCurrency = "USD";//Moeda de destino (Dólares)

            //Instância  do RestClient
            var client = new RestClient($"https://open.er-api.com/v6/latest/{baseCurrency}");
            var request = new RestRequest("/Index",Method.Post);
            request.AddParameter("app_id", apikey);

            //Executando a requisição
            var response = client.Execute(request);

            //Verificação da requisição
            if (response.IsSuccessful) 
            {
                //Analíse da requisição
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeRateResult>(response.Content);

                //Obtem a taxa de câmbio
                double exchangeRate = result.Rates[targetCurrency];

                //Exibe a taxa de câmbio
                Console.WriteLine($"A taxa de câmbio de {baseCurrency} para {targetCurrency} é : {exchangeRate}");
            }
            else 
            { 
            
                Console.WriteLine($"Erro na requisição: {response.ErrorMessage}");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}