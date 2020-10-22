FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Hangfire.Server/Hangfire.Server.csproj", "Hangfire.Server/"]
COPY ["Hangfire.Jobs/Hangfire.Jobs.csproj", "Hangfire.Jobs/"]
RUN dotnet restore "Hangfire.Server/Hangfire.Server.csproj"
COPY . .
WORKDIR "/src/Hangfire.Server"
RUN dotnet build "Hangfire.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hangfire.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hangfire.Server.dll"]