using Microsoft.AspNetCore.Mvc;

namespace ConversorDolar.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly ILogger<HistoricoController> _logger;
        private readonly HttpClient _httpClient = new();

        public HistoricoController(ILogger<HistoricoController> logger, HttpClient httpClient)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
