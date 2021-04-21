using CalculateFee.Domain.Usecases;
using Microsoft.AspNetCore.Mvc;

namespace CalculateFee.Controllers
{
    [Route("showmethecode")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly IGetRepositoryUrlUsecase getRepositoryUrlUsecase;

        public ShowMeTheCodeController(IGetRepositoryUrlUsecase getRepositoryUrlUsecase)
        {
            this.getRepositoryUrlUsecase = getRepositoryUrlUsecase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var repositoryUrl = getRepositoryUrlUsecase.Execute();
                return Ok(repositoryUrl);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}