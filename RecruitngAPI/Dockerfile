#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RecruitngAPI/RecruitngAPI.csproj", "RecruitngAPI/"]
COPY ["Recruiting.Infrastructure/Recruiting.Infrastructure.csproj", "Recruiting.Infrastructure/"]
COPY ["Recruiting.Core/Recruiting.Core.csproj", "Recruiting.Core/"]
RUN dotnet restore "RecruitngAPI/RecruitngAPI.csproj"
COPY . .
WORKDIR "/src/RecruitngAPI"
RUN dotnet build "RecruitngAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecruitngAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecruitngAPI.dll"]