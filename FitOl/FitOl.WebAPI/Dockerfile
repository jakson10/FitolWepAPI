#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FitOl.WebAPI/FitOl.WebAPI.csproj", "FitOl.WebAPI/"]
COPY ["FitOl.Service/FitOl.Service.csproj", "FitOl.Service/"]
COPY ["FitOl.Repository/FitOl.Repository.csproj", "FitOl.Repository/"]
COPY ["FitOl.Domain/FitOl.Domain.csproj", "FitOl.Domain/"]
RUN dotnet restore "FitOl.WebAPI/FitOl.WebAPI.csproj"
COPY . .
WORKDIR "/src/FitOl.WebAPI"
RUN dotnet build "FitOl.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitOl.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitOl.WebAPI.dll"]




