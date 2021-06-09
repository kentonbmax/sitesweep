FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

#runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT="Development"
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "sitesweep.dll"]