using System;
using System.Threading.Tasks;
using CalculaJuros.Domain.Exceptions;
using CalculaJuros.Domain.Services;
using CalculaJuros.Usecases;
using Moq;
using Xunit;

namespace CalculaJuros.Tests.Unit.Application.Usecases
{
    public class CalculateCompositeFeeUsecaseTest
    {
        [Theory]
        [InlineData(0, 5, 0.01, 0)]
        [InlineData(100, 5, 0.01, 105.1)]
        [InlineData(1000, 5, 0.01, 1051.01)]
        [InlineData(1254, 5, 0.01, 1317.96)]
        [InlineData(100000, 5, 0.01, 105101)]
        [InlineData(-100, 5, 0.01, -105.1)]
        [InlineData(-1000, 5, 0.01, -1051.01)]
        [InlineData(-1254, 5, 0.01, -1317.96)]
        [InlineData(-100000, 5, 0.01, -105101)]
        [InlineData(1000, 48, 0.01, 1612.22)]
        [InlineData(-1000, 48, 0.01, -1612.22)]
        [InlineData(1000, 1024, 0.01, 26612566.11)]
        [InlineData(-1000, 1024, 0.01, -26612566.11)]
        public async Task Execute_Should_Return_Correct_Value_When_Given_Correct_Values(decimal initialValue, int months, decimal mockedFee, decimal expected)
        {
            var feePercentageServiceMock = new Mock<IFeePercentageService>();
            feePercentageServiceMock.Setup(f => f.GetFeePercentage()).ReturnsAsync(mockedFee);

            var usecase = new CalculateCompositeFeeUsecase(feePercentageServiceMock.Object);

            var actual = await usecase.Execute(initialValue, months);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Execute_Should_Throw_Exception_When_Given_Too_Big_Value()
        {
            var mockedFee = 0.01m;
            var initialValue = decimal.MaxValue;
            var months = 5;

            var feePercentageServiceMock = new Mock<IFeePercentageService>();
            feePercentageServiceMock.Setup(f => f.GetFeePercentage()).ReturnsAsync(mockedFee);

            var usecase = new CalculateCompositeFeeUsecase(feePercentageServiceMock.Object);

            await Assert.ThrowsAsync<CalculateCompositeFeeUsecaseException>(async () =>
            {
                var actual = await usecase.Execute(initialValue, months);
            });
        }

        [Fact]
        public async Task Execute_Should_Throw_Exception_When_Given_Too_Small_Value()
        {
            var mockedFee = 0.01m;
            var initialValue = -decimal.MaxValue;
            var months = 5;

            var feePercentageServiceMock = new Mock<IFeePercentageService>();
            feePercentageServiceMock.Setup(f => f.GetFeePercentage()).ReturnsAsync(mockedFee);

            var usecase = new CalculateCompositeFeeUsecase(feePercentageServiceMock.Object);

            await Assert.ThrowsAsync<CalculateCompositeFeeUsecaseException>(async () =>
            {
                var actual = await usecase.Execute(initialValue, months);
            });
        }
    }
}