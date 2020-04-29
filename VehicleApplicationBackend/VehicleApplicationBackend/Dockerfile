FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["VehicleApplicationBackend/VehicleApplicationBackend.csproj", "VehicleApplicationBackend/"]
RUN dotnet restore "VehicleApplicationBackend/VehicleApplicationBackend.csproj"
COPY . .
WORKDIR "/src/VehicleApplicationBackend"
RUN dotnet build "VehicleApplicationBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehicleApplicationBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleApplicationBackend.dll"]