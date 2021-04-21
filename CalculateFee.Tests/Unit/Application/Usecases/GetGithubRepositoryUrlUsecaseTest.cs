using CalculateFee.Application.Usecases;
using Xunit;

namespace CalculateFee.Tests.Unit.Application.Usecases
{
    public class GetGithubRepositoryUrlUsecaseTest
    {
        [Fact]
        public void Execute_Should_Return_GitHub_Repository_Url() {
            var expected = "https://github.com/elbeshenrique/EasyFee";
            var usecase = new GetGithubRepositoryUrlUsecase();            
            var actual = usecase.Execute();
            Assert.Equal(expected, actual);
        }
    }
}