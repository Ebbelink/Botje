#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Botje.Mtg.Api/Botje.Mtg.Api.csproj", "Botje.Mtg.Api/"]
RUN dotnet restore "Botje.Mtg.Api/Botje.Mtg.Api.csproj"
COPY . .
WORKDIR "/src/Botje.Mtg.Api"
RUN dotnet build "Botje.Mtg.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Botje.Mtg.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Botje.Mtg.Api.dll"]