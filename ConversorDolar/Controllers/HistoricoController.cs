using Microsoft.AspNetCore.Mvc;

namespace ConversorDolar.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly ILogger<HistoricoController> _logger;

        public HistoricoController(ILogger<HistoricoController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
