# =========================
# BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copiar el proyecto
COPY ["miportafolio.csproj", "./"]

# Restaurar dependencias
RUN dotnet restore "miportafolio.csproj"

# Copiar el código fuente
COPY . .

# Compilar y publicar
RUN dotnet publish "miportafolio.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


# =========================
# RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

# Copiar la aplicación compilada
COPY --from=build /app/publish .

# Iniciar API
ENTRYPOINT ["dotnet", "miportafolio.dll"]