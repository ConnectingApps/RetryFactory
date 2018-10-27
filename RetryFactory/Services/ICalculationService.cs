using System.Threading.Tasks;
using RetryFactory.Models;

namespace TryCircuitBreaker.Services
{
    public interface ICalculationService
    {
        Task<CalculationResult> CallCalculation(int toCalculateWith);
    }
}