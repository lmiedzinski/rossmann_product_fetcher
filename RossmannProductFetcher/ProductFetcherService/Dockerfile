FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ProductFetcherService/ProductFetcherService.csproj ProductFetcherService/
RUN dotnet restore ProductFetcherService/ProductFetcherService.csproj
COPY . .
WORKDIR /src/ProductFetcherService
RUN dotnet build ProductFetcherService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ProductFetcherService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductFetcherService.dll"]
