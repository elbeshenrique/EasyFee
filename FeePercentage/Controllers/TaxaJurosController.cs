using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeePercentage.Controllers
{
    [Route("taxaJuros")]
    [ApiController]
    public class FeePercentageController : ControllerBase
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