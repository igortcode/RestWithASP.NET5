using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace RestWithASPNET.Controllers
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if(IsNumber(firstNumber) && IsNumber(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            
            return BadRequest();
        }

        private decimal ConvertToDecimal(string firstNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(firstNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumber(string firstNumber)
        {
            return double.TryParse(
                firstNumber,
                NumberStyles.Any,
                NumberFormatInfo.InvariantInfo,
                out double number
                );
        }
    }
}
