using System.Threading.Tasks;
using RetryFactory.Models;

namespace TryCircuitBreaker.Services
{
    /// <summary>
    /// Interface of the calculation service
    /// </summary>
    public interface ICalculationService
    {
        /// <summary>
        /// Call the calculation
        /// </summary>
        /// <param name="toCalculateWith"></param>
        /// <returns>The result of the calculation</returns>
        Task<CalculationResult> CallCalculation(int toCalculateWith);
    }
}