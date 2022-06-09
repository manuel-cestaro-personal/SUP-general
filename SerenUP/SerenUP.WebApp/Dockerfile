#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SerenUP.WebApp/SerenUP.WebApp.csproj", "SerenUP.WebApp/"]
RUN dotnet restore "SerenUP.WebApp/SerenUP.WebApp.csproj"
COPY . .
WORKDIR "/src/SerenUP.WebApp"
RUN dotnet build "SerenUP.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SerenUP.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SerenUP.WebApp.dll"]