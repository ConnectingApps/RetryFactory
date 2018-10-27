using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RetryFactory.Models;
using TryCircuitBreaker.Services;

namespace RetryFactory.Services
{
    /// <summary>
    /// This is a special service that uses a http client created by the new factory (in .NET Core 2.1)
    /// </summary>
    public class CalculationService : ICalculationService
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Creates the CalculationService
        /// </summary>
        /// <param name="client"></param>
        public CalculationService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5000/");
        }

        /// <summary>
        /// The calculation result calculator
        /// </summary>
        /// <param name="toCalculateWith"></param>
        /// <returns>The result of the calculation</returns>
        public async Task<CalculationResult> CallCalculation(int toCalculateWith)
        {
            var responseString = await _client.GetStringAsync($"api/Calculator/{toCalculateWith}");
            var result = JsonConvert.DeserializeObject<CalculationResult>(responseString);
            return result;
        }
    }
}