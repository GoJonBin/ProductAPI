# ========================
# Build stage
# ========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln .
COPY API/*.csproj API/
COPY Application/*.csproj Application/
COPY Domain/*.csproj Domain/
COPY Infrastructure/*.csproj Infrastructure/
COPY Tests/*.csproj Tests/

RUN dotnet restore

COPY . .
WORKDIR /src/API
RUN dotnet publish -c Release -o /app/publish

# ========================
# Runtime stage
# ========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "API.dll"]
