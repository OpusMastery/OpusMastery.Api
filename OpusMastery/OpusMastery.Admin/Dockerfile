FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS backend-build
WORKDIR /src
COPY ["OpusMastery.Admin/OpusMastery.Admin.csproj", "OpusMastery.Admin/"]
RUN dotnet restore "OpusMastery.Admin/OpusMastery.Admin.csproj"
COPY . .
WORKDIR "/src/OpusMastery.Admin"
RUN dotnet build "OpusMastery.Admin.csproj" -c Release -o /app/build

FROM backend-build AS publish
RUN dotnet publish "OpusMastery.Admin.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpusMastery.Admin.dll"]
