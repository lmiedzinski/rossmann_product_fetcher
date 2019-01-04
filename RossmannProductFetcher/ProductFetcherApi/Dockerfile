FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["./ProductFetcherApi.csproj", "ProductFetcherApi/"]
RUN dotnet restore "ProductFetcherApi/ProductFetcherApi.csproj"
COPY . ./ProductFetcherApi/
WORKDIR "/src/ProductFetcherApi"
RUN dotnet build "ProductFetcherApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductFetcherApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductFetcherApi.dll"]