FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim

WORKDIR /app

COPY bin/ /app/

RUN ["dotnet", "sitesweep.dll"]