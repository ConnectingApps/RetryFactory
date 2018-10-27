using System;
using Microsoft.AspNetCore.Mvc;
using RetryFactory.Models;

namespace RetryFactory.Controllers
{
    /// <summary>
    /// The controller class that simulates an unstable API. It can succeed. It can fail.
    /// </summary>
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        /// <summary>
        /// An unstable method to return the result of a calculation
        /// </summary>
        /// <param name="toCalculateWith"></param>
        /// <returns>The result of a calculation</returns>
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