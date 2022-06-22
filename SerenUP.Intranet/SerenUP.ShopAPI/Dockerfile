#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SerenUP.ShopAPI/SerenUP.ShopAPI.csproj", "SerenUP.ShopAPI/"]
RUN dotnet restore "SerenUP.ShopAPI/SerenUP.ShopAPI.csproj"
COPY . .
WORKDIR "/src/SerenUP.ShopAPI"
RUN dotnet build "SerenUP.ShopAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SerenUP.ShopAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SerenUP.ShopAPI.dll"]