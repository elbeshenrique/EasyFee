using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaxaJuros.Controllers
{
    [Route("taxaJuros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private const decimal FeePercentage = 0.01M;

        [HttpGet]
        public ActionResult<decimal> Get()
        {
            try
            {
                return Ok(FeePercentage);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}