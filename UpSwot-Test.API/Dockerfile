FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UpSwot-Test.API/UpSwot-Test.API.csproj", "UpSwot-Test.API/"]
COPY ["UpSwot-Test.BLL/UpSwot-Test.BLL.csproj", "UpSwot-Test.BLL/"]
COPY ["UpSwot-Test.DAL/UpSwot-Test.DAL.csproj", "UpSwot-Test.DAL/"]
RUN dotnet restore "UpSwot-Test.API/UpSwot-Test.API.csproj"
COPY . .
WORKDIR "/src/UpSwot-Test.API"
RUN dotnet build "UpSwot-Test.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UpSwot-Test.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UpSwot-Test.API.dll"]