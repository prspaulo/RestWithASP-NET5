﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet("{op}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string op, string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) 
            {
                if (op.Equals("sum"))
                {
                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                }
                else if (op.Equals("sub"))
                {
                    var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                    return Ok(sub.ToString());
                }
                else if (op.Equals("mult"))
                {
                    var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    return Ok(mult.ToString());
                }
                else
                {
                    var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    return Ok(div.ToString());
                }
            }
            return BadRequest("Invalid Input");
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

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
