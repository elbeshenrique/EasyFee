FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /src
COPY FeePercentage FeePercentage
RUN dotnet restore "FeePercentage/FeePercentage.csproj"

COPY FeePercentage.Tests FeePercentage.Tests
RUN dotnet restore "FeePercentage.Tests/FeePercentage.Tests.csproj"
RUN dotnet test "FeePercentage.Tests/FeePercentage.Tests.csproj"
