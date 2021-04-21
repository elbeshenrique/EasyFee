using System.Threading.Tasks;
using CalculateFee.Domain.Usecases;
using Microsoft.AspNetCore.Mvc;

namespace CalculateFee.Controllers
{
    [Route("calculajuros")]
    [ApiController]
    public class CalculateFeeController : ControllerBase
    {
        private readonly ICalculateFeeUsecase calculateFeeUsecase;

        public CalculateFeeController(ICalculateFeeUsecase calculateFeeUsecase)
        {
            this.calculateFeeUsecase = calculateFeeUsecase;
        }

        [HttpGet]
        public async Task<ActionResult<decimal>> Get(decimal valorInicial, int meses)
        {
            try
            {
                var finalValue = await calculateFeeUsecase.Execute(valorInicial, meses);
                return Ok(finalValue);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}