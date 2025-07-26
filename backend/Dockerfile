# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and projects
COPY *.sln ./
COPY Pictures.Domain/*.csproj Pictures.Domain/
COPY Pictures.Application/*.csproj Pictures.Application/
COPY Pictures.Infrastructure/*.csproj Pictures.Infrastructure/
COPY Pictures.Api/*.csproj Pictures.Api/

# Restore dependencies
RUN dotnet restore

# Copy full source
COPY . .

# Publish the API project
RUN dotnet publish Pictures.Api/Pictures.Api.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Pictures.Api.dll"]
