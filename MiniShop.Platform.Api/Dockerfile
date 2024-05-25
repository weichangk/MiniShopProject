#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM registry.cn-hangzhou.aliyuncs.com/newbe36524/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM registry.cn-hangzhou.aliyuncs.com/newbe36524/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MiniShop.Platform.Api/MiniShop.Platform.Api.csproj", "MiniShop.Platform.Api/"]
RUN dotnet restore "MiniShop.Platform.Api/MiniShop.Platform.Api.csproj"
COPY . .
WORKDIR "/src/MiniShop.Platform.Api"
RUN dotnet build "MiniShop.Platform.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniShop.Platform.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniShop.Platform.Api.dll"]