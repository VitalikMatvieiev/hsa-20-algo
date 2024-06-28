FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BBST_and_CountingSort/BBST_and_CountingSort.csproj", "BBST_and_CountingSort/"]
RUN dotnet restore "BBST_and_CountingSort/BBST_and_CountingSort.csproj"
COPY . .
WORKDIR "/src/BBST_and_CountingSort"
RUN dotnet build "BBST_and_CountingSort.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BBST_and_CountingSort.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BBST_and_CountingSort.dll"]
