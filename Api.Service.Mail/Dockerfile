FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5278
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 5278

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api.Service.Mail.csproj", "Api.Service.Mail/"]
RUN dotnet restore "Api.Service.Mail/Api.Service.Mail.csproj"

WORKDIR "/src/Api.Service.Mail"
COPY . .
RUN dotnet build "Api.Service.Mail.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Service.Mail.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Service.Mail.dll"]
