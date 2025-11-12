FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY DYECHEM/DYECHEM.sln DYECHEM/DYECHEM.sln
COPY DYECHEM DYECHEM
COPY ApplicationLayer ApplicationLayer
COPY CoreLayer CoreLayer
COPY DataBaseLayer DataBaseLayer
RUN dotnet restore "DYECHEM/DYECHEM.sln"
RUN dotnet publish "DYECHEM/DYECHEM.sln" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet","DYECHEM.dll"]
