FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#ENV ASPNETCORE_URLS=http://+:5277;https://+:7057
ENV ASPNETCORE_URLS=http://+:5277

EXPOSE 5277
#EXPOSE 7057

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api.Service.CryptoCheck.csproj", "Api.Service.CryptoCheck/"]
RUN dotnet restore "Api.Service.CryptoCheck/Api.Service.CryptoCheck.csproj"

WORKDIR "/src/Api.Service.CryptoCheck"
COPY . .
RUN dotnet build "Api.Service.CryptoCheck.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Service.CryptoCheck.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Service.CryptoCheck.dll"]
