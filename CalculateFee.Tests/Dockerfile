FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /src
COPY CalculateFee CalculateFee
RUN dotnet restore "CalculateFee/CalculateFee.csproj"

COPY CalculateFee.Tests CalculateFee.Tests
RUN dotnet restore "CalculateFee.Tests/CalculateFee.Tests.csproj"
RUN dotnet test "CalculateFee.Tests/CalculateFee.Tests.csproj"
