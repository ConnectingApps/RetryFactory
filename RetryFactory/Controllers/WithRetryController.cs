using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RetryFactory.Models;
using TryCircuitBreaker.Services;

namespace RetryFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithRetryController : ControllerBase
    {
        private readonly ICalculationService _calculationService;

        public WithRetryController(ICalculationService calculationservice)
        {
            _calculationService = calculationservice;
        }

        // GET api/values/5
        [HttpGet("{input}")]
        public async Task<ActionResult<CalculationResult>> Get(int input)
        {
            return await _calculationService.CallCalculation(input);
        }
    }
}