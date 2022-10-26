#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PruebaSearch/PruebaSearch.csproj", "PruebaSearch/"]
RUN dotnet restore "PruebaSearch/PruebaSearch.csproj"
COPY . .
WORKDIR "/src/PruebaSearch"
RUN dotnet build "PruebaSearch.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaSearch.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaSearch.dll"]