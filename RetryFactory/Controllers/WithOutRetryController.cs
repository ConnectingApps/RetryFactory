using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RetryFactory.Models;
using TryCircuitBreaker.Services;

namespace RetryFactory.Controllers
{
    [Route("api/[controller]")]
    public class WithOutRetryController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public WithOutRetryController(ICalculationService calculationservice)
        {
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }

        // GET api/values/5
        [HttpGet("{toCalculateWith}")]
        public async Task<ActionResult<CalculationResult>> Get(int toCalculateWith)
        {
            var responseString = await _httpClient.GetStringAsync($"api/Calculator/{toCalculateWith}");
            var result = JsonConvert.DeserializeObject<CalculationResult>(responseString);
            return result;
        }
    }
}