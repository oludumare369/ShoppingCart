#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Service/ShoppingCart.API/ShoppingCart.API.csproj", "Service/ShoppingCart.API/"]
COPY ["Service/ShoppingCart.Application/ShoppingCart.Application.csproj", "Service/ShoppingCart.Application/"]
COPY ["Service/ShoppingCart.Domain/ShoppingCart.Domain.csproj", "Service/ShoppingCart.Domain/"]
COPY ["Service/ShoppingCart.Infrastructure/ShoppingCart.Infrastructure.csproj", "Service/ShoppingCart.Infrastructure/"]
RUN dotnet restore "Service/ShoppingCart.API/ShoppingCart.API.csproj"
COPY . .
WORKDIR "/src/Service/ShoppingCart.API"
RUN dotnet build "ShoppingCart.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCart.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.API.dll"]