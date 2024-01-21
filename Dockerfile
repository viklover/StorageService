FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY . .
COPY /src/Repository/Resources resources
RUN dotnet restore
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV ASPNETCORE_URLS=http://0.0.0.0:80
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/resources /app/resources 
ENV ASPNETCORE_ENVIRONMENT=Development
ENV CASSANDRA_SCHEMAS_DIRECTORY="/app/resources/Schemas"
ENTRYPOINT ["dotnet", "Api.dll"]
