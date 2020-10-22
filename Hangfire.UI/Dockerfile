FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Hangfire.UI/Hangfire.UI.csproj", "Hangfire.UI/"]
COPY ["Hangfire.Jobs/Hangfire.Jobs.csproj", "Hangfire.Jobs/"]
RUN dotnet restore "Hangfire.UI/Hangfire.UI.csproj"
COPY . .
WORKDIR "/src/Hangfire.UI"
RUN dotnet build "Hangfire.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hangfire.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hangfire.UI.dll"]