FROM mcr.microsoft.com/dotnet/sdk:8.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY . /src
WORKDIR /src
RUN dotnet build "CouscousApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CouscousApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CouscousApi.dll"]
