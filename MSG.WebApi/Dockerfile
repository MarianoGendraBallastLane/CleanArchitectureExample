#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MSG.WebApi/MSG.WebApi.csproj", "MSG.WebApi/"]
COPY ["MSG.Application/MSG.Application.csproj", "MSG.Application/"]
COPY ["MSG.Domain/MSG.Domain.csproj", "MSG.Domain/"]
COPY ["MSG.Persistence/MSG.Persistence.csproj", "MSG.Persistence/"]
RUN dotnet restore "MSG.WebApi/MSG.WebApi.csproj"
COPY . .
WORKDIR "/src/MSG.WebApi"
RUN dotnet build "MSG.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MSG.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSG.WebApi.dll"]