using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalulaJuros.Domain.Usecases;
using CalulaJuros.Usecases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalulaJuros.Controllers
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
        public async Task<ActionResult<decimal>> CalculaJuros(decimal valorInicial, int tempo)
        {
            try
            {
                var finalValue = await calculateFeeUsecase.Execute(valorInicial, tempo);
                return Ok(finalValue);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}