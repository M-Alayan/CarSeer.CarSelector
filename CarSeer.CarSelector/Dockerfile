FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published output of the ASP.NET Core application into the container
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarSeer.CarSelector.csproj", "."]
RUN dotnet restore "./CarSeer.CarSelector.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CarSeer.CarSelector.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarSeer.CarSelector.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarSeer.CarSelector.dll"]