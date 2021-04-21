using FeePercentage.Application.Usecases;
using Xunit;

namespace FeePercentage.Tests.Controllers
{
    public class GetCompositeFeePercentageUsecaseTest
    {
        [Fact]
        public void Execute_Should_Return_Fee_Percentage()
        {
            var expected = 0.01M;
            var usecase = new GetCompositeFeePercentageUsecase();
            var actual = usecase.Execute();
            Assert.Equal(expected, actual);
        }
    }
}