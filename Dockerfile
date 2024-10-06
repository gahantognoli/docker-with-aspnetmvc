FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN mkdir /app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app
COPY mvc1.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o dist

FROM base AS final
WORKDIR /dist
COPY --from=publish /app/dist .
ENTRYPOINT [ "dotnet", "mvc1.dll" ]