FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Concs.Api/Concs.Api.csproj", "Concs.Api/"]
COPY ["Concs.Id/Concs.Id.csproj", "Concs.Api/"]
RUN dotnet restore "./Concs.Api/Concs.Api.csproj"
COPY . .
WORKDIR "/src/Concs.Api"
RUN dotnet build "./Concs.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Concs.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Concs.Api.dll"]