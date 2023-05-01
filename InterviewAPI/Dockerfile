#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV InterviewTrainningDb = "Data Source=192.168.254.139,1433;Initial Catalog=InterviewTrainningDb;User ID=sa;Password=Unt11326860$"
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InterviewAPI/InterviewAPI.csproj", "InterviewAPI/"]
COPY ["InterviewCore/InterviewCore.csproj", "InterviewCore/"]
COPY ["InterviewInfrastructure/InterviewInfrastructure.csproj", "InterviewInfrastructure/"]
RUN dotnet restore "InterviewAPI/InterviewAPI.csproj"
COPY . .
WORKDIR "/src/InterviewAPI"
RUN dotnet build "InterviewAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterviewAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterviewAPI.dll"]