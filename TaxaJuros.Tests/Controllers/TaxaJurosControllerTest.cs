using TaxaJuros.Controllers;
using Xunit;

namespace TaxaJuros.Tests.Controllers
{
    public class TaxaJurosControllerTest
    {
        [Fact]
        public void Get_ShouldReturn()
        {
            var controller = new TaxaJurosController();
            var actionResult = controller.Get();
            var value = actionResult.Value;

            decimal expected = 0.01M;
            Assert.Equal(expected, value);
        }
    }
}