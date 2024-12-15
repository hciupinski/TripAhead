FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/payments/TripAhead.Services.Payments.API/TripAhead.Services.Payments.API.csproj", "services/payments/TripAhead.Services.Payments.API/"]
RUN dotnet restore "services/payments/TripAhead.Services.Payments.API/TripAhead.Services.Payments.API.csproj"
COPY . .
WORKDIR "/src/services/payments/TripAhead.Services.Payments.API"
RUN dotnet build "TripAhead.Services.Payments.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TripAhead.Services.Payments.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TripAhead.Services.Payments.API.dll"]
