using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhCalculatorService.Core;

namespace PhCalculatorService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return Content("Calculator!");
        }

        [HttpGet("[action]/{number1:int}/{number2:int}")]
        public IActionResult Somar(int number1, int number2)
        {
            var calculator = new Calculator();
            var sumResultAsString = calculator.Sum(number1, number2).ToString();
            return Content(sumResultAsString);
        }
    }
}
