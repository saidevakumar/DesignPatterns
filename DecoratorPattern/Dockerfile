FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DecoratorPattern.csproj", "./"]
RUN dotnet restore "DecoratorPattern.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DecoratorPattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DecoratorPattern.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DecoratorPattern.dll"]
