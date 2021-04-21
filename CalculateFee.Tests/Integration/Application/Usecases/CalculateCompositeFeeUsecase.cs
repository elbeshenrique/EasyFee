using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using CalculateFee.Constants;
using CalculateFee.Domain.Exceptions;
using CalculateFee.Services;
using CalculateFee.Usecases;
using Xunit;
using Xunit.Abstractions;
using HttpClientHandler = CalculateFee.Application.Drivers.HttpClientHandler;

namespace CalculateFee.Tests.Integration.Application.Usecases
{
    public class CalculateCompositeFeeUsecaseTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CalculateCompositeFeeUsecaseTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(100, 5, 105.1)]
        [InlineData(1000, 5, 1051.01)]
        [InlineData(1254, 5, 1317.96)]
        [InlineData(100000, 5, 105101)]
        [InlineData(-100, 5, -105.1)]
        [InlineData(-1000, 5, -1051.01)]
        [InlineData(-1254, 5, -1317.96)]
        [InlineData(-100000, 5, -105101)]
        [InlineData(1000, 48, 1612.22)]
        [InlineData(-1000, 48, -1612.22)]
        [InlineData(1000, 1024, 26612566.11)]
        [InlineData(-1000, 1024, -26612566.11)]
        public async Task Execute_Should_Return_Valid_Value(decimal initialValue, int months, decimal expected)
        {
            var hostIp = Environment.GetEnvironmentVariable(EnvironmentVariables.HostIp);

            var httpClient = new HttpClient();
            var httpHandler = new HttpClientHandler(httpClient);
            var feePercentageService = new FeePercentageService(
                httpHandler,
                String.Format(FeePercentageService.UrlEndpointFormat, hostIp)
            );
            var calculateCompositeFeeUsecase = new CalculateCompositeFeeUsecase(feePercentageService);

            var actual = await calculateCompositeFeeUsecase.Execute(initialValue, months);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Execute_Should_Throw_Exception_When_InitialValue_Is_Too_Big()
        {
            var hostIp = Environment.GetEnvironmentVariable(EnvironmentVariables.HostIp);

            var httpClient = new HttpClient();
            var httpHandler = new HttpClientHandler(httpClient);
            var feePercentageService = new FeePercentageService(
                httpHandler,
                String.Format(FeePercentageService.UrlEndpointFormat, hostIp)
            );
            var calculateCompositeFeeUsecase = new CalculateCompositeFeeUsecase(feePercentageService);

            var initialValue = Decimal.MaxValue;
            var months = 1;

            await Assert.ThrowsAsync<CalculateCompositeFeeUsecaseException>(async () =>
            {
                await calculateCompositeFeeUsecase.Execute(initialValue, months);
            });
        }

        [Fact]
        public async Task Execute_Should_Throw_Exception_When_Months_Value_Is_Too_Big()
        {
            var hostIp = Environment.GetEnvironmentVariable(EnvironmentVariables.HostIp);

            var httpClient = new HttpClient();
            var httpHandler = new HttpClientHandler(httpClient);
            var feePercentageService = new FeePercentageService(
                httpHandler,
                String.Format(FeePercentageService.UrlEndpointFormat, hostIp)
            );
            var calculateCompositeFeeUsecase = new CalculateCompositeFeeUsecase(feePercentageService);

            var initialValue = 1;
            var months = Int32.MaxValue;

            await Assert.ThrowsAsync<CalculateCompositeFeeUsecaseException>(async () =>
            {
                await calculateCompositeFeeUsecase.Execute(initialValue, months);
            });
        }

        [Fact]
        public async Task Execute_Should_Throw_Exception_When_InitialValue_Is_Too_Small()
        {
            var hostIp = Environment.GetEnvironmentVariable(EnvironmentVariables.HostIp);

            var httpClient = new HttpClient();
            var httpHandler = new HttpClientHandler(httpClient);
            var feePercentageService = new FeePercentageService(
                httpHandler,
                String.Format(FeePercentageService.UrlEndpointFormat, hostIp)
            );
            var calculateCompositeFeeUsecase = new CalculateCompositeFeeUsecase(feePercentageService);

            var initialValue = -Decimal.MaxValue;
            var months = 1;

            await Assert.ThrowsAsync<CalculateCompositeFeeUsecaseException>(async () =>
            {
                await calculateCompositeFeeUsecase.Execute(initialValue, months);
            });
        }

        [Fact]
        public async Task Execute_Should_Return_Zero_When_Months_Value_Is_Negative()
        {
            var hostIp = Environment.GetEnvironmentVariable(EnvironmentVariables.HostIp);

            var httpClient = new HttpClient();
            var httpHandler = new HttpClientHandler(httpClient);
            var feePercentageService = new FeePercentageService(
                httpHandler,
                String.Format(FeePercentageService.UrlEndpointFormat, hostIp)
            );
            var calculateCompositeFeeUsecase = new CalculateCompositeFeeUsecase(feePercentageService);

            var initialValue = 1;
            var months = -Int32.MaxValue;
            var expected = 0;
            var actual = await calculateCompositeFeeUsecase.Execute(initialValue, months);

            Assert.Equal(expected, actual);
        }
    }
}