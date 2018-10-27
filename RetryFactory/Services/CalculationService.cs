using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RetryFactory.Models;

namespace TryCircuitBreaker.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly HttpClient _client;

        public CalculationService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:5000/");
        }

        public async Task<CalculationResult> CallCalculation(int toCalculateWith)
        {
            var responseString = await _client.GetStringAsync($"api/Calculator/{toCalculateWith}");
            var result = JsonConvert.DeserializeObject<CalculationResult>(responseString);
            return result;
        }
    }
}
