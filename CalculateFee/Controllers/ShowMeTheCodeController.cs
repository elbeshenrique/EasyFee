using Microsoft.AspNetCore.Mvc;

namespace CalculateFee.Controllers
{
    [Route("showmethecode")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private const string GitHubRepositoryUrl = "https://github.com/elbeshenrique/EasyFee";

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GitHubRepositoryUrl);
        }
    }
}