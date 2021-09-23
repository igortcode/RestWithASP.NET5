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
        public IActionResult Sum(string firstNumber, string secondNumber)
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

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if(IsNumber(firstNumber) && IsNumber(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest();
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (IsNumber(firstNumber) && IsNumber(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest();
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumber(firstNumber) && IsNumber(secondNumber) && IsZero(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest();
        }

        private bool IsZero(string secondNumber)
        {
            if (ConvertToDecimal(secondNumber) > 0)
            {
                return true;
            }
            else
                return false;
        }

        [HttpGet("ave/{num1}/{num2}")]
        public IActionResult Mean(string num1, string num2)
        {
            if(IsNumber(num1) && IsNumber(num2))
            {
                return Ok(((ConvertToDecimal(num1) + ConvertToDecimal(num2)) / 2).ToString());
            }
            return BadRequest();
        }

        [HttpGet("sqrt/{number}")]
        public IActionResult Sqrt(string number)
        {
            if (IsNumber(number))
            {
                return Ok(Math.Sqrt(ConvertToDouble(number)).ToString());
            }
            
            return BadRequest();
        }

        private double ConvertToDouble(string num)
        {
            double doubleValue;
            if (double.TryParse(num, out doubleValue))
            {
                return doubleValue;
            }
            return 0;
        }
    }
}
