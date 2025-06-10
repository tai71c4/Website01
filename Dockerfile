FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5240
ENV ASPNETCORE_URLS=http://+:5240

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WebsiteBanPhuKien.csproj", "."]
RUN dotnet restore "WebsiteBanPhuKien.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "WebsiteBanPhuKien.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebsiteBanPhuKien.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebsiteBanPhuKien.dll"]