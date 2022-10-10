using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet5Udemy.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{operador}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string operador, string firstNumber, string secondNumber)
        {
            if (operador == "sum")
            {
                if (isNumeric(firstNumber) && isNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                }
            }
            else if (operador == "div" || operador == "Div")
            {
                if (isNumeric(firstNumber) && isNumeric(secondNumber))
                {
                    var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    return Ok(div.ToString());
                }

            }
            else if (operador == "mult" || operador == "Mult")
            {
                if (isNumeric(firstNumber) && isNumeric(secondNumber))
                {
                    var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    return Ok(mult.ToString());
                }

            }
            else if (operador == "Raiz" || operador == "raiz")
            {
                if (isNumeric(firstNumber) && isNumeric(secondNumber))
                {
                    var raiz = Math.Sqrt(Double.Parse(firstNumber));

                    return Ok(raiz.ToString());
                }
            }
            else if (operador == "media" || operador == "Media")
            {
                if (isNumeric(firstNumber) && isNumeric(secondNumber))
                {
                    var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                    return Ok(media.ToString());
                }    
            }
            return BadRequest("Invalid Input");
        }
        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

    }
}