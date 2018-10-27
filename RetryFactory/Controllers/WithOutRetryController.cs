using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RetryFactory.Models;

namespace RetryFactory.Controllers
{
    /// <summary>
    /// A controller to call the calculator without retries
    /// </summary>
    [Route("api/[controller]")]
    public class WithOutRetryController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Creates the controller
        /// </summary>
        public WithOutRetryController()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }

        /// <summary>
        /// Call the calulcation web api without retries
        /// </summary>
        /// <param name="toCalculateWith"></param>
        /// <returns>Calculation result</returns>
        [HttpGet("{toCalculateWith}")]
        public async Task<ActionResult<CalculationResult>> Get(int toCalculateWith)
        {
            var responseString = await _httpClient.GetStringAsync($"api/Calculator/{toCalculateWith}");
            var result = JsonConvert.DeserializeObject<CalculationResult>(responseString);
            return result;
        }
    }
}