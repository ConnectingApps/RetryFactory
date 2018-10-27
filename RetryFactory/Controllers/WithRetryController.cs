using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RetryFactory.Models;
using TryCircuitBreaker.Services;

namespace RetryFactory.Controllers
{
    /// <summary>
    /// A controller that uses a retry mechanism
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WithRetryController : ControllerBase
    {
        private readonly ICalculationService _calculationService;

        /// <summary>
        /// Create the retry controller
        /// </summary>
        /// <param name="calculationservice"></param>
        public WithRetryController(ICalculationService calculationservice)
        {
            _calculationService = calculationservice;
        }

        /// <summary>
        /// Call the calculation service with retry mechanism
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The result of the called service </returns>
        [HttpGet("{input}")]
        public async Task<ActionResult<CalculationResult>> Get(int input)
        {
            return await _calculationService.CallCalculation(input);
        }
    }
}