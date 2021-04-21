using FeePercentage.Controllers;
using Xunit;

namespace FeePercentage.Tests.Controllers
{
    public class FeePercentageControllerTest
    {
        [Fact]
        public void Get_ShouldReturn()
        {
            var controller = new FeePercentageController();
            var actionResult = controller.Get();
            var value = actionResult.Value;

            decimal expected = 0.01M;
            Assert.Equal(expected, value);
        }
    }
}