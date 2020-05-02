FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["VehicleSimulator/VehicleSimulator.csproj", "VehicleSimulator/"]
RUN dotnet restore "VehicleSimulator/VehicleSimulator.csproj"
COPY . .
WORKDIR "/src/VehicleSimulator"
RUN dotnet build "VehicleSimulator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehicleSimulator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleSimulator.dll"]