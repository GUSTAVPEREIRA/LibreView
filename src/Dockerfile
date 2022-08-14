FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

COPY Web/API /var/www/app/Web/API
COPY Application /var/www/app/Application
COPY Core /var/www/app/Core
COPY Infrastructure /var/www/app/Infrastructure

RUN dotnet publish /var/www/app/Web/API -r linux-x64 -c Release -o out

WORKDIR /var/www/app/Web/API
RUN dotnet build API.csproj -r linux-x64 -c Release -o /var/www/app/build

FROM build AS publish
WORKDIR /var/www/app/Web/API
RUN dotnet publish API.csproj -r linux-x64 -c Release -o /var/www/app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /var/www/app/Web/API
COPY --from=publish /var/www/app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
EXPOSE 9502