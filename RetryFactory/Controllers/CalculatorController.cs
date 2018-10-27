using System;
using Microsoft.AspNetCore.Mvc;
using RetryFactory.Models;

namespace RetryFactory.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/<controller>/5
        [HttpGet("{toCalculateWith}")]
        public ActionResult<CalculationResult> Get(int toCalculateWith)
        {           
            if (DateTime.Now.Ticks % 2 == 0)
            {
                return new CalculationResult
                {
                    Duplicate = toCalculateWith * 2,
                    Triple = toCalculateWith * 3
                };
            }
            Console.Beep(700, 200);
            return new ObjectResult("Failed")
            {
                StatusCode = 500
            };
        }
    }
}