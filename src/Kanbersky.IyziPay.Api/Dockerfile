#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Kanbersky.IyziPay.Api/Kanbersky.IyziPay.Api.csproj", "src/Kanbersky.IyziPay.Api/"]
COPY ["src/Kanbersky.IyziPay.Api/Kanbersky.IyziPay.Business.csproj", "src/Kanbersky.IyziPay.Business/"]
COPY ["src/Kanbersky.IyziPay.Api/Kanbersky.IyziPay.Tests.csproj", "src/Kanbersky.IyziPay.Tests/"]
RUN dotnet restore "src/Kanbersky.IyziPay.Api/Kanbersky.IyziPay.Api.csproj"
COPY . .
WORKDIR "/src/src/Kanbersky.IyziPay.Api"
RUN dotnet build "Kanbersky.IyziPay.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kanbersky.IyziPay.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kanbersky.IyziPay.Api.dll"]