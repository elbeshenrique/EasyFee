using System;
using System.Threading.Tasks;
using CalculateFee.Application.Drivers;
using CalculateFee.Domain.Exceptions;
using CalculateFee.Services;
using Moq;
using Xunit;

namespace CalculateFee.Tests.Unit.Application.Services
{
    public class FeePercentageServiceTest
    {
        [Fact]
        public async Task GetFeePercentage_Should_Return_Valid_Value()
        {
            var expected = 0.01m;

            var httpHandlerMock = new Mock<IHttpHandler>();
            httpHandlerMock
                .Setup(h => h.GetAsyncAsString(It.IsAny<string>()))
                .ReturnsAsync("0.01");

            var feePercentageService = new FeePercentageService(httpHandlerMock.Object, "");
            var actual = await feePercentageService.GetFeePercentage();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetFeePercentage_Should_Throw_Exception_When_HttpHandler_Fails()
        {
            var httpHandlerMock = new Mock<IHttpHandler>();
            httpHandlerMock
                .Setup(h => h.GetAsyncAsString(It.IsAny<string>()))
                .Throws(new Exception());

            var feePercentageService = new FeePercentageService(httpHandlerMock.Object, "");

            await Assert.ThrowsAsync<FeePercentageServiceException>(async () =>
            {
                var actual = await feePercentageService.GetFeePercentage();
            });
        }
    }
}