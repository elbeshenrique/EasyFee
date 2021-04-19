using Microsoft.AspNetCore.Mvc;

namespace CalulaJuros.Controllers
{
    [Route("showmethecode")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private const string GitHubRepositoryUrl = "https://github.com/elbeshenrique/JurosFacil";

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GitHubRepositoryUrl);
        }
    }
}