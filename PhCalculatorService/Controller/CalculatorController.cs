using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PhCalculatorService.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Calculator controller testes unitários com erro!";
        }
    }
}
