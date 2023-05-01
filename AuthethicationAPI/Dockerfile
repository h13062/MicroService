#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV AuthenticationDb = "Data Source=192.168.254.139,1433;Initial Catalog=AuthenticationDb;User ID=sa;Password=Unt11326860$"
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AuthethicationAPI/AuthenticationAPI.csproj", "AuthethicationAPI/"]
COPY ["Authenthication.Infrastructure/Authentication.Infrastructure.csproj", "Authenthication.Infrastructure/"]
COPY ["Authethication.Core/Authentication.Core.csproj", "Authethication.Core/"]
RUN dotnet restore "AuthethicationAPI/AuthenticationAPI.csproj"
COPY . .
WORKDIR "/src/AuthethicationAPI"
RUN dotnet build "AuthenticationAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthenticationAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationAPI.dll"]