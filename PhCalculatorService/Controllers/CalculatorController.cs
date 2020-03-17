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

        /// <summary>
        /// Sum 2 integer numbers.
        /// </summary>
        /// <param name="number1">First Number</param>
        /// <param name="number2">Second Number</param>
        /// <returns>sum result between number1 and number2</returns>
        [HttpGet("[action]/{number1:int}/{number2:int}")]
        public IActionResult Sum(int number1, int number2)
        {
            var calculator = new Calculator();
            var resultAsString = calculator.Sum(number1, number2).ToString();
            return Content(resultAsString);
        }

        /// <summary>
        /// Subtract 2 integer numbers.
        /// </summary>
        /// <param name="number1">First Number</param>
        /// <param name="number2">Second Number</param>
        /// <returns>subtract result between number1 and number2</returns>
        [HttpGet("[action]/{number1:int}/{number2:int}")]
        public IActionResult Subtract(int number1, int number2)
        {
            var calculator = new Calculator();
            var resultAsString = calculator.Subtract(number1, number2).ToString();
            return Content(resultAsString);
        }

        /// <summary>
        /// Multiply 2 integer numbers.
        /// </summary>
        /// <param name="number1">First Number</param>
        /// <param name="number2">Second Number</param>
        /// <returns>multiplication result between number1 and number2</returns>
        [HttpGet("[action]/{number1:int}/{number2:int}")]
        public IActionResult Multiply(int number1, int number2)
        {
            var calculator = new Calculator();
            var resultAsString = calculator.Multiply(number1, number2).ToString();
            return Content(resultAsString);
        }
    }
}
