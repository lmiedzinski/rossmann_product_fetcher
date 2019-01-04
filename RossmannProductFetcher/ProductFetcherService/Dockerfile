FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ProductFetcherService.csproj", "ProductFetcherService/"]
RUN dotnet restore "ProductFetcherService/ProductFetcherService.csproj"
COPY . ./ProductFetcherService/
WORKDIR "/src/ProductFetcherService"
RUN dotnet build "ProductFetcherService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductFetcherService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductFetcher.dll"]
