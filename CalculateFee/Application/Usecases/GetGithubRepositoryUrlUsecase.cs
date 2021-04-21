using CalculateFee.Domain.Usecases;

namespace CalculateFee.Application.Usecases
{
    public class GetGithubRepositoryUrlUsecase : IGetRepositoryUrlUsecase
    {
        private const string GitHubRepositoryUrl = "https://github.com/elbeshenrique/EasyFee";

        public string Execute()
        {
            return GitHubRepositoryUrl;
        }
    }
}