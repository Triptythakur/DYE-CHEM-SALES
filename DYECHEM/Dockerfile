# Use the official ASP.NET Core runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage - use SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all project files
COPY ../ApplicationLayer/ApplicationLayer.csproj ./ApplicationLayer/
COPY ../CoreLayer/CoreLayer.csproj ./CoreLayer/
COPY ../DataBaseLayer/DataBaseLayer.csproj ./DataBaseLayer/
COPY ./DYCHEM.csproj ./DYCHEM/

# Restore dependencies
RUN dotnet restore "./DYCHEM/DYCHEM.csproj"

# Copy the rest of the source code
COPY .. .

# Build the app
WORKDIR /src/DYCHEM
RUN dotnet build "DYCHEM.csproj" -c Release -o /app/build

# Publish the app (optimized for deployment)
FROM build AS publish
RUN dotnet publish "DYCHEM.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage - runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DYCHEM.dll"]
