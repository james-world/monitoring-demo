FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Acme.csproj", "./"]
RUN dotnet restore "./Acme.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Acme.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "Acme.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*::80
ENTRYPOINT ["dotnet", "Acme.dll"]
